using System.Linq;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class SinusoidalPreset : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public SinusoidalPreset(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 6;
            Title = "Change the Load by a sinusoid";
            Description = "The price changes according to the sinusoid.\n" +
                          "The Load level changes according to the sinusoid.\n" +
                          "Load level settings affect the maximum number of traders (threads) and the minimum interval between placing orders.";
        }

        public override TradersSettings Build(int payload)
        {
            var sets = new TradersSettings
            {
                PricingSets = new TradersSettings.PricingSettings
                {
                    PricingMode = PricingSettingsMode.Sinusoidal,
                    SinusPeriodMs = 2000,
                    SinusAmplitudePercent = 1
                },
                MoneyManagementSets = new TradersSettings.MoneyManagementSettings
                {
                    Tickers = defaultSettings.MoneyManagementSets.Tickers.ToList(),
                    FixedTickerIndex = 0,
                    LotsMax = 20,
                    LotsMin = 10,
                    TradeRandomTicker = false
                },
                TradeSets = new TradersSettings.TradeSettings
                {
                    MakersCount = 0,
                    OneShotTradersCount = 0,
                    ProbOfNewOrder = 70,
                    ProbOfMassCancel = 15,
                    ProbOfCancelOrder = 15,
                    ProbErrorRequest = 0
                },
                PayloadSets = new TradersSettings.PayloadSettings
                {
                    Mode = PayloadSettingsMode.Sinusoidal,
                    RequestPerIterationProb = 100,
                    SinusoidPeriodMs = 1000 * 10                    
                }
            };
            defaultSettings.CopyCommonSettingsToTarget(sets);
            var paySets = sets.PayloadSets;

            if (payload < 4)
            {
                paySets.TradersCount = payload * 10;
                paySets.SleepInterval = 15;
            }
            else
            {
                paySets.TradersCount = payload * 10;
                paySets.SleepInterval = 5;
            }

            return sets;
        }

        public override string MakeDescription(int payload)
        {
            var sets = Build(payload);
            var reqPerSec = sets.PayloadSets.TradersCount * 1000M / (sets.PayloadSets.SleepInterval + 1) *
                            sets.PayloadSets.RequestPerIterationProb / 100M;
            return $"{sets.PayloadSets.TradersCount} traders.\n" +
                   $"~ {reqPerSec:F1} requests per second";
        }
    }
}
