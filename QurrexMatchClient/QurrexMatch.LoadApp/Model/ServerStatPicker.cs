using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// A class that starts a thread to obtain the servers statistics on a regular basis
    /// through the special matching server's API
    /// Statistics gathered is stored in a file
    /// </summary>
    public class ServerStatPicker
    {
        /// <summary>
        /// the settings to get the interval between storing statistics
        /// and the matching server's stat REST URI
        /// </summary>
        private readonly TradersSettings settings;

        /// <summary>
        /// flag is set when stopping the statistics' gathering thread (task)
        /// </summary>
        private volatile bool isStopping;

        /// <summary>
        /// statistics' gathering thread (task)
        /// </summary>
        private Task routine;

        /// <summary>
        /// the flag is used for not to flood log with
        /// </summary>
        private bool alreadyLoggedError;

        /// <summary>
        /// a helper class for logging messages
        /// </summary>
        private readonly Logger logMessage;

        /// <summary>
        /// a file stream for appenging new data obtained from server,
        /// being opened on Start() and closed on Stop() calls
        /// </summary>
        private StreamWriter fileWriter;

        /// <summary>
        /// the path to the statistics file
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// used for prepending some data to the statistics file
        /// </summary>
        private bool firstMessage = true;

        public ServerStatPicker(TradersSettings settings, Logger logMessage)
        {
            this.settings = settings;
            this.logMessage = logMessage;
            filePath = ExecutablePath.Combine("serverlog.json");
        }

        public void Start()
        {
            if (!settings.LogServerStatistics) return;
            fileWriter = new StreamWriter(filePath, false, Encoding.ASCII);
            routine = new Task(ThreadRoutine);
            routine.Start();
        }

        public void Stop()
        {
            if (!settings.LogServerStatistics) return;
            isStopping = true;
            routine.Wait();
            fileWriter.Write("]");
            fileWriter.Close();
        }

        /// <summary>
        /// called after the test finishes to move the statistics file
        /// in the report directory
        /// </summary>
        public void CopyReportToTargetDir(string targetDir)
        {
            if (!File.Exists(filePath)) return;
            var destPath = Path.Combine(targetDir, "serverstat.js");
            if (File.Exists(destPath)) File.Delete(destPath);
            File.Move(filePath, destPath);
        }

        /// <summary>
        /// statistics' peeking routine
        /// </summary>
        private void ThreadRoutine()
        {
            const int sleepInterval = 100;
            var lastActionTime = Timeframe.RoundTime(DateTime.Today, settings.StatisticsTimeframeSeconds);

            while (!isStopping)
            {
                Thread.Sleep(sleepInterval);
                var time = Timeframe.RoundTime(DateTime.Now, settings.StatisticsTimeframeSeconds);
                if (time == lastActionTime) continue;                
                PickServerStat(time);
                lastActionTime = time;
            }
        }

        /// <summary>
        /// a method that actually gets the statistics from the matching server
        /// </summary>
        private void PickServerStat(DateTime time)
        {
            try
            {
                var req = WebRequest.Create(settings.StatUri);
                var resp = req.GetResponse();
                string data;
                using (var sr = new StreamReader(resp.GetResponseStream(), Encoding.ASCII))
                    data = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(data))
                    StoreData(data, time);
            }
            catch (Exception e)
            {
                if (alreadyLoggedError) return;
                logMessage.LogMessage($"Error gathering server stats from {settings.StatUri}: {e.GetType().Name}, {e.Message}", LoggingLevel.Error);
                alreadyLoggedError = true;
            }
        }

        /// <summary>
        /// a method that stores data gathered in a file through fileWriter
        /// </summary>
        private void StoreData(string data, DateTime time)
        {
            data = $"{{\"time\":\"{time:yyyy-MM-dd HH:mm:ss}\", " + data.Substring(1);

            if (firstMessage)
            {
                fileWriter.Write("window.serverStat = [");
                fileWriter.Write(data);
                firstMessage = false;
                return;
            }
            fileWriter.Write(",\n");
            fileWriter.Write(data);
        }
    }
}
