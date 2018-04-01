using System;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// open, high, low and close values per timeframe
    /// OHLC or candlestick
    /// </summary>
    public class Candle
    {
        /// <summary>
        /// open, high, low, close values
        /// s states for sum
        /// </summary>
        public float o, h, l, c, s;

        /// <summary>
        /// "volume" - count of data stored in the candle
        /// </summary>
        public int v;

        /// <summary>
        /// candle open time
        /// </summary>
        public DateTime t;

        public Candle()
        {
        }

        public Candle(DateTime time, float val)
        {
            t = time;
            o = val;
            h = val;
            l = val;
            c = val;
            v = 1;
            s = val;
        }

        public override string ToString()
        {
            return $"{t:mm:ss.fff} {o:F0},{h:F0},{l:F0},{c:F0}, {v}";
        }
    }
}
