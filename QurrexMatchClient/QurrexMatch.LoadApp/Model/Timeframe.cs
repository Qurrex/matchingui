using System;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// a class using to quantify statistics data
    /// splitting it by provided timeframe
    /// (1 second by default)
    /// </summary>
    public static class Timeframe
    {
        public static DateTime RoundTime(DateTime time, int timeframeSeconds)
        {
            var seconds = time.Second / timeframeSeconds;
            seconds *= timeframeSeconds;
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, seconds);
        }
    }
}
