using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// thread safe collection of OHLC (candlestick) data
    /// </summary>
    public class ThreadSafeCandleList
    {
        /// <summary>
        /// internal list
        /// </summary>
        public readonly List<Candle> Candles = new List<Candle>();

        /// <summary>
        /// used to updated the last value in the collection
        /// </summary>
        [JsonIgnore]
        private Candle lastCandle;

        /// <summary>
        /// thread-safe access manager
        /// </summary>
        [JsonIgnore]
        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        /// <summary>
        /// add a new value (OHLC) or update the last one
        /// </summary>
        public void StoreValueTime(float newVal, int timeframeSeconds)
        {
            locker.EnterWriteLock();
            try
            {
                var time = Timeframe.RoundTime(DateTime.Now, timeframeSeconds);
                if (lastCandle == null || lastCandle.t != time)
                {
                    lastCandle = new Candle(time, newVal);
                    Candles.Add(lastCandle);
                    return;
                }

                lastCandle.h = Math.Max(lastCandle.h, newVal);
                lastCandle.l = Math.Min(lastCandle.h, newVal);
                lastCandle.c = newVal;
                lastCandle.s += newVal;
                lastCandle.v++;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
