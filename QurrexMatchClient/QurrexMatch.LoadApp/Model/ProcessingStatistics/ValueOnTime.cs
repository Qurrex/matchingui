using System;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// just a time - value pair
    /// </summary>
    public class ValueOnTime
    {
        /// <summary>
        /// the value being stored
        /// </summary>
        public int v;

        /// <summary>
        /// candle open time
        /// </summary>
        public DateTime t;

        public ValueOnTime()
        {
        }

        public ValueOnTime(DateTime time, int val)
        {
            t = time;
            v = val;
        }

        public override string ToString()
        {
            return $"{t:mm:ss.fff} {v}";
        }
    }
}
