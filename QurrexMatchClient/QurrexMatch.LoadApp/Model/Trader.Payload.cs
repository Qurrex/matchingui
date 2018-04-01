using System;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// here the "trader" thread's payload is being modulated
    /// here we decide how much to "sleep" before placing a request
    /// or should the "trader" just skip the step
    /// </summary>
    public partial class Trader
    {
        /// <summary>
        /// used in FadeIn or Stairs payload mode to simplify the calculation
        /// </summary>
        private bool startCooldownPassed;

        /// <summary>
        /// the payload calculation helper for Mode = Sinusoid
        /// </summary>
        private readonly SinusoidPayloadCalculator sinusPayloadCalc;

        /// <summary>
        /// used in each iteration to determine:
        /// should the trader skip the step and
        /// what be the next sleep interval
        /// </summary>
        struct PayloadToken
        {
            public bool skipStep;

            public int nextSleepInterval;
        }

        /// <summary>
        /// depending on the payload settings the following moment in time
        /// will be shift on a constant or a variable (sinusoidal) time span
        /// </summary>
        private PayloadToken GetNextSleepInterval()
        {
            var token = GetNextSleepIntervalToken();
            if (!startCooldownPassed)
            {
                token.nextSleepInterval = Math.Max(settings.CooldownMilliseconds, token.nextSleepInterval);
                startCooldownPassed = true;
            }

            return token;
        }

        /// <summary>
        /// used in GetNextSleepInterval
        /// </summary>
        private PayloadToken GetNextSleepIntervalToken()
        {
            var interval = settings.PayloadSets.SleepInterval;

            if (settings.PayloadSets.Mode == PayloadSettingsMode.Even)
                return new PayloadToken { nextSleepInterval = interval };
            if (settings.PayloadSets.Mode == PayloadSettingsMode.Sinusoidal)
                return new PayloadToken { nextSleepInterval = sinusPayloadCalc.GetNextInterval() };

            return GetStairsOrFadeInModeInterval();
        }

        /// <summary>
        /// get the next "sleep" interval or a probability to skip the step
        /// for the Stairs and FadeIn payload modes only
        /// </summary>
        /// <returns></returns>
        private PayloadToken GetStairsOrFadeInModeInterval()
        {
            var interval = settings.PayloadSets.SleepInterval;

            if (payloadSetup)
                return new PayloadToken { nextSleepInterval = interval };
            var secsPassed = (DateTime.Now - statistics.timeStarted).TotalSeconds;
            var period = settings.PayloadSets.Mode == PayloadSettingsMode.FadeIn
                ? settings.PayloadSets.FadingInSeconds
                : settings.PayloadSets.StepsCount * settings.PayloadSets.SecondsPerStep;

            if (secsPassed >= period)
            {
                if (settings.PayloadSets.Mode == PayloadSettingsMode.FadeIn)
                {
                    payloadSetup = true;
                    return new PayloadToken {nextSleepInterval = interval};
                }
                secsPassed = period;
            }

            var stepsCount = settings.PayloadSets.Mode == 
                PayloadSettingsMode.Stairs || settings.PayloadSets.Mode == PayloadSettingsMode.StairsDown ? settings.PayloadSets.StepsCount : 100;

            var step = secsPassed * stepsCount / period;
            if (settings.PayloadSets.Mode == PayloadSettingsMode.StairsDown)
                step = stepsCount - step;

            if (settings.PayloadSets.Mode == PayloadSettingsMode.Stairs)
                step = Math.Floor(step);
            if (tradersTotal > 5)
            {
                // we probably turn the trader off
                var activeCount = (int)Math.Round(tradersTotal * step / stepsCount);
                return new PayloadToken
                {
                    nextSleepInterval = interval,
                    skipStep = activeCount < seqNum
                };
            }
            double fadeCoeff = 1 + 4 / (1 + step);

            // we just change sleep interval
            return new PayloadToken
            {
                nextSleepInterval = (int) Math.Ceiling(interval * fadeCoeff)
            };
        }
    }
}
