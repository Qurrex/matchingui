using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// raw data for reports
    /// count of orders placed, responses obtained
    /// </summary>
    public partial class Statistics
    {
        /// <summary>
        /// statistics timeframe - 1 second by default
        /// affects all the charts: roundtrip intervals, requests per second etc
        /// </summary>
        public int timeframeSeconds;

        /// <summary>
        /// all kinds of requests sent to the matching server
        /// </summary>
        public int orderRequestsSend;

        /// <summary>
        /// order cancel requests sent to the matching server
        /// </summary>
        public int cancelRequestsSend;

        /// <summary>
        /// total errors while sending requests
        /// </summary>
        public int sendRequestErrorCount;

        /// <summary>
        /// total responses from server
        /// </summary>
        public int totalResponses;

        /// <summary>
        /// count of error responses obtained from server
        /// </summary>
        public int errorResponses;

        /// <summary>
        /// count of order execution reports obtained from server
        /// </summary>
        public int executionReports;

        /// <summary>
        /// test's start time
        /// </summary>
        public DateTime timeStarted;

        /// <summary>
        /// test's finish time
        /// </summary>
        public DateTime timeFinished;

        /// <summary>
        /// count of "traders" by role: takers, makers, one-shot-traders
        /// </summary>
        public Dictionary<TraderModusOperandi, int> tradersByRole;

        public int TotalReqsSend => orderRequestsSend + cancelRequestsSend;

        /// <summary>
        /// messages sent count, the key is type
        /// </summary>
        public Dictionary<string, int> messagesSentByType = new Dictionary<string, int>();

        /// <summary>
        /// messages parsed count, the key is type
        /// </summary>
        public Dictionary<string, int> messagesParsedByType = new Dictionary<string, int>();

        /// <summary>
        /// test's duration in string format
        /// </summary>
        public string Elapsed
        {
            get
            {
                var totalSecs = (int) Math.Round((timeFinished - timeStarted).TotalSeconds);
                var minutes = totalSecs / 60;
                totalSecs -= minutes * 60;
                return $"{minutes} min {totalSecs} sec";
            }
        }

        /// <summary>
        /// test's settings
        /// </summary>
        public TradersSettings settings;

        public Statistics(TradersSettings settings)
        {
            this.settings = settings;
            timeframeSeconds = settings.StatisticsTimeframeSeconds;
        }

        /// <summary>
        /// just store the test's start time
        /// </summary>
        public void Start()
        {
            timeStarted = DateTime.Now;
        }

        /// <summary>
        /// store the test's finish time
        /// </summary>
        public void Stop()
        {
            timeFinished = DateTime.Now;
        }

        /// <summary>
        /// increment count of errors while sending requests, thread-safe
        /// </summary>
        public void IncrementSendRequestErrorCount()
        {
            Interlocked.Increment(ref sendRequestErrorCount);
        }

        public void IncrementOrderRequestsSend()
        {
            Interlocked.Increment(ref orderRequestsSend);
            IncrementAndStoreRequestsCount();
        }

        public void IncrementCancelRequestsSend()
        {
            Interlocked.Increment(ref cancelRequestsSend);
            IncrementAndStoreRequestsCount();
        }

        public void IncrementTotalResponses()
        {
            Interlocked.Increment(ref totalResponses);
            IncrementAndStoreResponsesCount();
        }

        public void IncrementErrorResponses()
        {
            Interlocked.Increment(ref errorResponses);
        }

        public void IncrementExecutionReports()
        {
            Interlocked.Increment(ref executionReports);
        }

        /// <summary>
        /// make a JSON string out of the data stored
        /// </summary>
        public string Stringify(bool indent = false)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }

        /// <summary>
        /// store the JSON in the file provided by path
        /// </summary>
        public void StoreInFile(string path, bool indent = false)
        {
            var json = Stringify(indent);
            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                sw.Write(json);
        }
    }
}
