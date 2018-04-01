using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// a class for storing data as a vector at a moment of time
    /// </summary>
    public class ThreadSafeVectorList
    {
        /// <summary>
        /// some data stored: { time: [ value1, ... valueN ] }
        /// </summary>
        public readonly List<VectorByTime> Vectors = new List<VectorByTime>();

        /// <summary>
        /// used to update the collection
        /// </summary>
        [JsonIgnore]
        private VectorByTime lastValue;

        /// <summary>
        /// thread-safe access manager
        /// </summary>
        [JsonIgnore]
        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        /// <summary>
        /// append the new value or udate the last one
        /// </summary>
        public void StoreValueTime(UInt32 newVal, int volume, int timeframeSeconds)
        {
            locker.EnterWriteLock();
            try
            {                
                var time = Timeframe.RoundTime(DateTime.Now, timeframeSeconds);
                if (lastValue == null || lastValue.t != time)
                {
                    lastValue = new VectorByTime(time, newVal);
                    Vectors.Add(lastValue);
                    return;
                }
                
                lastValue.AddValue(newVal);
                lastValue.volume = volume;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
