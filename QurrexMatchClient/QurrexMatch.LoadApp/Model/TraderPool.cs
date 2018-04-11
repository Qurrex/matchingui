using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.QurrexConnection;
using QurrexMatch.Lib.Model.Response;
using QurrexMatch.Lib.Model.Response.ExecReport;
using QurrexMatch.LoadApp.Model.ProcessingStatistics;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// N parallel threads sharing M TCP/IP connections
    /// to send requests and process responses
    /// </summary>
    public class TraderPool
    {
        /// <summary>
        /// testing session's complete settings
        /// </summary>
        public TradersSettings settings;

        /// <summary>
        /// statistics gathered within the test
        /// </summary>
        public Statistics statistics;

        /// <summary>
        /// action called to store (log) the message
        /// </summary>
        private readonly Action<string> logMessageAction;

        /// <summary>
        /// wrapper around logMessage delegate
        /// </summary>
        private Logger logger;

        /// <summary>
        /// virtual "traders" placing orders in separate threads and sharing the connections
        /// </summary>
        private List<Trader> traders;

        /// <summary>
        /// a number of TCP/IP connection to the Qurrex server
        /// </summary>
        private readonly List<Connection> connectionPool = new List<Connection>();

        /// <summary>
        /// action is called when the testing session finishes
        /// </summary>
        private Action onStop;

        /// <summary>
        /// hashset out of tickers, grouped by Id
        /// </summary>
        private Dictionary<int, Ticker> tickerById = new Dictionary<int, Ticker>();

        /// <summary>
        /// a process that reads and stores the server's statistics
        /// </summary>
        public ServerStatPicker serverStatPicker;

        /// <summary>
        /// used for not firing "connected" event several times
        /// </summary>
        private bool onConnectedWasFired;

        /// <summary>
        /// the event handler called upon receiving first message from server
        /// </summary>
        private readonly Action onConnected;

        /// <param name="logMessage">method to log a string</param>
        public TraderPool(Action<string> logMessage, Action onConnected)
        {
            logMessageAction = logMessage;
            this.onConnected = onConnected;
        }

        /// <param name="onStop">action called when the pool stops</param>
        public void Start(Action onStop)
        {
            this.onStop = onStop;
            ReadSettings();
            logger = new Logger(logMessageAction, settings.LoggingLevel);
            logger.LogMessage("Starting test", LoggingLevel.Critical);
            statistics = new Statistics(settings);
            serverStatPicker = new ServerStatPicker(settings, logger);
            var fairPriceMaker = new FairPriceMaker(settings);
            try
            {
                for (var i = 0; i < settings.PayloadSets.TradersCount; i++)
                {
                    var conn = new Connection(settings.Uri, logger, i);
                    conn.onResponse += OnResponse;
                    conn.Open();
                    connectionPool.Add(conn);
                }                
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error opening connection: {ex.GetType().Name}: {ex.Message}", LoggingLevel.Error);
                onStop();
                return;
            }

            var connIndex = 0;
            var rolePool = Enumerable.Range(0, settings.TradeSets.MakersCount).Select(i => TraderModusOperandi.Maker).ToList();
            rolePool.AddRange(Enumerable.Range(0, settings.TradeSets.OneShotTradersCount).Select(i => TraderModusOperandi.OneShotTaker));
            rolePool.AddRange(Enumerable.Range(0, settings.PayloadSets.TradersCount).Select(i => TraderModusOperandi.Taker));

            traders = Enumerable.Range(0, settings.PayloadSets.TradersCount).Select(i =>
            {
                var trader = new Trader(connectionPool[connIndex++], statistics, settings, fairPriceMaker, rolePool[i], i, settings.PayloadSets.TradersCount)
                {
                    AccountId = $"Trader_{i}",
                    ClearingAccountId = $"Qurrex_{connIndex}"
                };
                if (connIndex == connectionPool.Count) connIndex = 0;
                return trader;
            }).ToList();

            // the first trader watches for the test to stop on timeout
            traders.First().onTimer = () =>
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    logger.LogMessage("Test is stopping by timeout...", LoggingLevel.Critical);
                    Stop();
                });
            };
            traders.First().timeoutTime = DateTime.Now.AddSeconds(settings.TestDurationSeconds);

            statistics.tradersByRole = traders.GroupBy(t => t.modusOperandi).ToDictionary(t => t.Key, t => t.Count());
            statistics.Start();
            traders.ForEach(t => t.Start());
            serverStatPicker.Start();
            logger.LogMessage("Test has been started", LoggingLevel.Critical);
        }

        /// <summary>
        /// synchronously stop the test
        /// </summary>
        public void Stop()
        {
            try
            {
                var tasks = traders.Select(t => new Task(() =>
                {
                    try
                    {
                        t.Stop();
                    }
                    catch (Exception e)
                    {
                        logger.LogMessage($"Error stopping trader {t.AccountId}: {e.GetType().Name}: {e.Message}", LoggingLevel.Error);
                    }
                })).ToArray();
                foreach (var t in tasks)
                    t.Start();
                Task.WaitAll(tasks);
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error stopping traders pool: {ex.GetType().Name}: {ex.Message}", LoggingLevel.Critical);
            }

            statistics.messagesParsedByType = GetTotalMessagesReceivedByType();
            statistics.messagesSentByType = GetTotalMessagesSentByType();
            statistics.Stop();
            Thread.Sleep(settings.CooldownMilliseconds);

            foreach (var conn in connectionPool)
                try
                {                
                    conn.Close();
                }
                catch (Exception ex)
                {
                    logger.LogMessage($"Error closing connection: {ex.GetType().Name}: {ex.Message}", LoggingLevel.Error);
                }

            try
            {
                serverStatPicker.Stop();
            }
            catch (Exception e)
            {
                logger.LogMessage($"Error stopping server statistics: {e.GetType().Name}: {e.Message}", LoggingLevel.Error);
            }
            Thread.Sleep(300);
            onStop();
        }

        /// <summary>
        /// read test's settings - "trader" threads, payload, pricing, logging etc
        /// </summary>
        /// <returns></returns>
        private void ReadSettings()
        {
            settings = TradersSettings.ReadSettings();
            tickerById = settings.MoneyManagementSets.Tickers.ToDictionary(t => t.Id, t => t);
        }

        /// <summary>
        /// called by the connection objects when response is received
        /// safe (exception-free) wrapper on OnResponseUnsafe
        /// </summary>
        private void OnResponse(BaseResponse baseResponse, UInt32 processedIntervalMs, int connectionId)
        {
            if (!onConnectedWasFired)
            {
                onConnectedWasFired = true;
                onConnected();
            }
            statistics.IncrementTotalResponses();
            try
            {
                OnResponseUnsafe(baseResponse, processedIntervalMs);
            }
            catch (Exception e)
            {
                logger.LogMessage($"Error while parsing: {e.GetType().Name} - {e.Message}", LoggingLevel.Error);
                // almost all the errors ends up
                // restarting the connection
                connectionPool[connectionId].Reconnect();
            }
        }

        /// <summary>
        /// update statistics and notify the "trader" thread
        /// </summary>
        private void OnResponseUnsafe(BaseResponse baseResponse, UInt32 processedIntervalMs)
        {
            //logger.LogMessage(baseResponse.ToString(), LoggingLevel.Verbose);
            if (baseResponse is RejectResponse)
                statistics.IncrementErrorResponses();

            if (baseResponse is ExecutionReport)
            {
                statistics.IncrementExecutionReports();
                UpdateTradesByExecReport((ExecutionReport)baseResponse);
            }

            if (baseResponse is OrderResponse)
            {
                var ord = (OrderResponse)baseResponse;
                if (processedIntervalMs > 0)
                    statistics.StoreProcessingTime(processedIntervalMs, connectionPool.Sum(p => p.requestsWaitingForResponses));

                var acc = ord.OriginRequest.TraderAccountId;
                if (!string.IsNullOrEmpty(acc))
                {
                    var trader = traders.FirstOrDefault(t => t.AccountId == acc);
                    trader?.OnOrderResponse(ord);
                }
            }
        }

        /// <summary>
        /// used upon the pool's stopped to gather a part of total statistics
        /// </summary>
        private Dictionary<string, int> GetTotalMessagesReceivedByType()
        {
            return SumTypeCountHashes(connectionPool.Select(c => c.MessagesByType));
        }

        /// <summary>
        /// again, used upon the pool's stopped to gather a part of total statistics
        /// </summary>
        private Dictionary<string, int> GetTotalMessagesSentByType()
        {
            return SumTypeCountHashes(traders.Select(c => c.RequestsSentByType));
        }

        /// <summary>
        /// used in both GetTotalMessagesReceivedByType and GetTotalMessagesSentByType
        /// </summary>
        private Dictionary<string, int> SumTypeCountHashes(IEnumerable<Dictionary<Type, int>> hashes)
        {
            var counts = new Dictionary<string, int>();
            foreach (var hash in hashes)
                foreach (var tp in hash)
                {
                    var key = tp.Key.Name;
                    if (counts.ContainsKey(key)) counts[key] = counts[key] + tp.Value;
                    else counts.Add(key, tp.Value);
                }
            return counts;
        }

        /// <summary>
        /// used in OnResponseUnsafe to update the statistics
        /// </summary>
        private void UpdateTradesByExecReport(ExecutionReport report)
        {
            if (report.ExecReport.DealsCount == 0) return;
            var tickerId = report.OriginRequest.InstrumentId;
            if (!tickerById.TryGetValue(tickerId, out var ticker))
            {
                logger.LogMessage($"Error while parsing: ticker #{tickerId} was not found", LoggingLevel.Error);
                return;
            }
            
            double totalPrice = 0, totalAmount = 0;

            for (var i = 0; i < report.ExecReport.DealsCount; i++)
            {
                var price = ticker.GetAbsPriceFromScaledD(report.ExecReport.Deals[i].Price);
                totalPrice += price * report.ExecReport.Deals[i].Amount;
                totalAmount += report.ExecReport.Deals[i].Amount;
            }

            if (totalAmount == 0) return;
            var weightedPrice = totalPrice / totalAmount;

            statistics.StoreExecPrice((float) weightedPrice);
        }
    }
}
