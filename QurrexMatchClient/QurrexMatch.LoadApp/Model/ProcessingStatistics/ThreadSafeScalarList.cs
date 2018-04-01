using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// thread safe list of pairs { time, value }
    /// </summary>
    public class ThreadSafeScalarList
    {
        /// <summary>
        /// the internal list
        /// </summary>
        public readonly List<ValueOnTime> Values = new List<ValueOnTime>();

        /// <summary>
        /// used for updating the last value in the collection
        /// </summary>
        [JsonIgnore]
        private ValueOnTime lastTime;

        /// <summary>
        /// thread safe access manager
        /// </summary>
        [JsonIgnore]
        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        /// <summary>
        /// update the last value in the collection or add a new one
        /// </summary>
        public void StoreValueTime(int newVal, int timeframeSeconds)
        {
            locker.EnterWriteLock();
            try
            {
                var time = Timeframe.RoundTime(DateTime.Now, timeframeSeconds);
                if (lastTime == null || lastTime.t != time)
                {
                    lastTime = new ValueOnTime(time, newVal);
                    Values.Add(lastTime);
                    return;
                }
                lastTime.v += newVal;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
