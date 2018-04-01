using System;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// storing metrics quantified by timeframe
    /// </summary>
    public partial class Statistics
    {
        /// <summary>
        /// request - response roundtrip times
        /// </summary>
        public ThreadSafeVectorList roundtripTimes = new ThreadSafeVectorList();

        /// <summary>
        /// orders' execution prices in OHLC (candlestick) format
        /// </summary>
        public ThreadSafeCandleList execPriceCandles = new ThreadSafeCandleList();

        /// <summary>
        /// requests per timeframe (1s) in OHLC (candlestick) format
        /// </summary>
        public ThreadSafeScalarList requestsPerSecond = new ThreadSafeScalarList();

        /// <summary>
        /// resposes per timeframe (1s) in OHLC (candlestick) format
        /// </summary>
        public ThreadSafeScalarList responsesPerSecond = new ThreadSafeScalarList();

        public void StoreProcessingTime(UInt32 procTimeTicks, int volume)
        {
            roundtripTimes.StoreValueTime(procTimeTicks / 10, volume, timeframeSeconds);
        }

        public void StoreExecPrice(float price)
        {
            execPriceCandles.StoreValueTime(price, timeframeSeconds);
        }

        public void IncrementAndStoreRequestsCount()
        {
            requestsPerSecond.StoreValueTime(1, timeframeSeconds);
        }

        public void IncrementAndStoreResponsesCount()
        {
            responsesPerSecond.StoreValueTime(1, timeframeSeconds);
        }
    }
}
