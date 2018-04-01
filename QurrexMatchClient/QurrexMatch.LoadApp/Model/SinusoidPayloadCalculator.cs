using System;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// a helper class to adjust "trader's" payload (requests per seconds) by sinusoid
    /// </summary>
    public class SinusoidPayloadCalculator
    {
        /// <summary>
        /// default interval between requests, mils
        /// </summary>
        private readonly int interval;

        /// <summary>
        /// sinusoid period
        /// </summary>
        private readonly int periodMs;

        /// <summary>
        /// sinusoid "phase", radians
        /// </summary>
        private double phase;

        public SinusoidPayloadCalculator(TradersSettings settings)
        {
            periodMs = settings.PayloadSets.SinusoidPeriodMs;
            interval = settings.PayloadSets.SleepInterval;
        }

        /// <summary>
        /// get a time interval for the "trader" thread to sleep before some action
        /// </summary>
        public int GetNextInterval()
        {
            var now = DateTime.Now;
            var mils = (now.Second % periodMs) * 1000 + now.Millisecond;

            phase = Math.PI * mils / periodMs;
            var coeff = 0.65 * Math.Sin(phase);
            return (int)Math.Round(interval * (1 + coeff));
        }
    }
}
