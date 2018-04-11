using System;
using System.Collections.Generic;
using System.Threading;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.QurrexConnection;
using QurrexMatch.Lib.Model.Request;
using QurrexMatch.Lib.Model.Response;
using QurrexMatch.LoadApp.Model.ProcessingStatistics;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// a "trader", sending requests from time to time
    /// </summary>
    public partial class Trader
    {
        /// <summary>
        /// the way the trader trades - taker, maker etc
        /// </summary>
        public TraderModusOperandi modusOperandi;

        /// <summary>
        /// a managed thread-safe wrapper for the TCP/IP matching server connection
        /// may be shared among other "traders"
        /// </summary>
        private readonly Connection connection;

        /// <summary>
        /// used to make quite a number of decisions: about placing or cancelling orders, choosing among
        /// the trading instruments etc
        /// </summary>
        private readonly Random rand = new Random();

        /// <summary>
        /// trading settings... all the "trader" has to know to make orders an adjust its payload
        /// </summary>
        private readonly TradersSettings settings;

        /// <summary>
        /// stopping flag: when set the trader's operating loop breaks
        /// </summary>
        private volatile bool isStopping;

        /// <summary>
        /// a thread where all the actions take place
        /// </summary>
        private readonly Thread tradeThread;

        /// <summary>
        /// a statistics object reference to report on requests / responses count
        /// </summary>
        private readonly Statistics statistics;

        /// <summary>
        /// a helper object that reports on the "fair" market price
        /// </summary>
        private readonly FairPriceMaker priceMaker;

        /// <summary>
        /// a storage that counts request sent by type, used for the test's final statistics
        /// </summary>
        private readonly Dictionary<Type, int> requestsSentByType = new Dictionary<Type, int>
        {
            {typeof(OrderRequest), 0},
            {typeof(CancelOrderRequest), 0},
            {typeof(MassCancelRequest), 0}
        };

        public Dictionary<Type, int> RequestsSentByType => requestsSentByType;

        /// <summary>
        /// this value is set in the pool
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// this Id could be a constant
        /// </summary>
        public string ClearingAccountId { get; set; } = "MatchingTest";

        /// <summary>
        /// if e.g. payload is set to fading in
        /// payloadSetup = true when payload has set on its final value
        /// </summary>
        private bool payloadSetup;

        /// <summary>
        /// the responses obtained from the server - thread-safe and restricted list
        /// </summary>
        private readonly OrderResponseSafeList orderResponses = new OrderResponseSafeList(25, 10);

        /// <summary>
        /// a method call by the trader to make a record in the log
        /// </summary>
        private Action<string, LoggingLevel> logMessage;

        /// <summary>
        /// a method that the trader calls when the test is timed out
        /// if only timeout is set
        /// </summary>
        public Action onTimer;

        /// <summary>
        /// used when this particular "trader" whatches for the test to end
        /// this time the test finishes
        /// </summary>
        public DateTime timeoutTime;

        /// <summary>
        /// the trader's sequence number (ordnial)
        /// used to swith trading on / off while payload is changed
        /// </summary>
        public int seqNum;

        /// <summary>
        /// total traders' count
        /// </summary>
        public int tradersTotal;

        public Trader(Connection connection, 
            Statistics statistics, 
            TradersSettings sets,
            FairPriceMaker priceMaker,
            TraderModusOperandi modusOperandi,
            int seqNum,
            int tradersTotal)
        {
            this.connection = connection;
            this.statistics = statistics;
            this.priceMaker = priceMaker;
            this.modusOperandi = modusOperandi;
            this.seqNum = seqNum;
            this.tradersTotal = tradersTotal;
            settings = sets;
            sinusPayloadCalc = new SinusoidPayloadCalculator(sets);
            tradeThread = new Thread(ThreadRoutine);
        }

        public void Start()
        {
            tradeThread.Start();
        }

        public void Stop()
        {
            isStopping = true;
            tradeThread.Join();
        }

        /// <summary>
        /// when the server responds on this "trader" request - just store the response
        /// to process it later
        /// </summary>
        public void OnOrderResponse(OrderResponse resp)
        {
            orderResponses.PushResponse(resp);
        }

        /// <summary>
        /// an infinite loop of making actions (sending requests)
        /// breaks by the Stop() method - setting isStopping flag true
        /// </summary>
        private void ThreadRoutine()
        {
            while (!isStopping)
            {
                var payToken = GetNextSleepInterval();
                Thread.Sleep(payToken.nextSleepInterval);
                
                // if this trader acts as a watchdog ...
                if (timeoutTime != default(DateTime))
                    if (DateTime.Now >= timeoutTime)
                    {
                        timeoutTime = default(DateTime);
                        onTimer();
                        break;
                    }
                if (payToken.skipStep)
                    continue;
                if (!connection.Connected)
                    continue;

                if (rand.Next(0, 100) < settings.PayloadSets.RequestPerIterationProb)
                    PerformAction();
            }
        }

        /// <summary>
        /// make an action as a taker, market maker or a noe-shot trader (see TraderModusOperandi)
        /// </summary>
        private void PerformAction()
        {
            if (!connection.Connected) return;
            if (modusOperandi == TraderModusOperandi.Taker)
                TradeRandom();
            if (modusOperandi == TraderModusOperandi.OneShotTaker)
                TryTakeTheBook();
        }

        /// <summary>
        /// send a new order request to the matching server through connection
        /// </summary>
        private void SendNewOrderRequest(OrderRequest req)
        {
            requestsSentByType[req.GetType()] = requestsSentByType[req.GetType()] + 1;
            statistics.IncrementOrderRequestsSend();
            try
            {
                if (connection.SendRequest(req))
                    statistics.IncrementSendRequestErrorCount();
            }
            catch
            {
            }
        }

        /// <summary>
        /// send a cancel order order request to the matching server through connection
        /// </summary>        
        private void SendCancelOrderRequest(CancelOrderRequest req)
        {
            requestsSentByType[req.GetType()] = requestsSentByType[req.GetType()] + 1;
            statistics.IncrementCancelRequestsSend();
            try
            {
                if (connection.SendRequest(req))
                    statistics.IncrementSendRequestErrorCount();
            }
            catch
            {
            }
        }

        /// <summary>
        /// send a mass cancel order request ("broadcast") to close all the account's orders
        /// </summary>
        /// <param name="tickerId"></param>
        private void SendMassCancelRequest(int tickerId)
        {
            requestsSentByType[typeof(MassCancelRequest)] = requestsSentByType[typeof(MassCancelRequest)] + 1;
            statistics.IncrementCancelRequestsSend();
            try
            {
                if (connection.SendRequest(new MassCancelRequest
                {
                    InstrumentId = tickerId,
                    ClearingAccountId = ClearingAccountId,
                    TraderAccountId = AccountId,
                    CancelMode = MassCancelMode.Connect
                }))
                    statistics.IncrementSendRequestErrorCount();
            }
            catch
            {
            }
        }
    }
}
