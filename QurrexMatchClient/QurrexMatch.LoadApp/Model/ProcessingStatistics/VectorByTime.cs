using System;
using System.Collections.Generic;

namespace QurrexMatch.LoadApp.Model.ProcessingStatistics
{
    /// <summary>
    /// stores a nuber of values per timeframe
    /// </summary>
    public class VectorByTime
    {
        /// <summary>
        /// period's start
        /// </summary>
        public DateTime t;

        /// <summary>
        /// some data stored as a vector
        /// </summary>
        public List<UInt32> vector = new List<UInt32>();

        /// <summary>
        /// a value acompanying the vector
        /// </summary>
        public int volume;

        public VectorByTime()
        {
        }

        public VectorByTime(DateTime time, UInt32 val)
        {
            t = time;
            vector.Add(val);
        }

        public void AddValue(UInt32 val) => vector.Add(val);

        public override string ToString()
        {
            return $"{t:mm:ss.fff} {vector.Count}";
        }
    }
}
