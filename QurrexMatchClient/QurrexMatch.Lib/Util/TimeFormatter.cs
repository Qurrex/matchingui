using System;

namespace QurrexMatch.Lib.Util
{
    /// <summary>
    /// convert server's UInt64 timestamp to DateTime
    /// </summary>
    public static class TimeFormatter
    {
        public static DateTime UInt64ToTime(this UInt64 time)
        {
            var timePart = time / 1000000000;
            var mils = (time - timePart * 1000000000) / 1.0000000;
            var date = new DateTime(1970, 1, 1).AddSeconds(timePart);
            return date.AddMilliseconds(mils);
        }
    }
}
