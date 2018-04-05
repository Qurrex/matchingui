using System.Linq;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class OneShotPreset : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public OneShotPreset(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 5;
            Title = "One-shot trader";
            Description = "A number of traders place orders randomly at the market price. " +
                          "One-shot trader places a \"superorder\", that takes all placed orders.\n\n" +
                          "The price changes according to the sinusoid.\n" +
                          "The Load level value does not change in time.\n" +
                          "Load level settings affect the number of traders (threads) and the interval between placing orders.";
        }

        public override TradersSettings Build(int payload)
        {
            var sets = new TradersSettings
            {
                PricingSets = new TradersSettings.PricingSettings
                {
                    PricingMode = PricingSettingsMode.Sinusoidal,
                    SinusAmplitudePercent = 5,
                    SinusPeriodMs = 3000
                },
                MoneyManagementSets = new TradersSettings.MoneyManagementSettings
                {
                    Tickers = defaultSettings.MoneyManagementSets.Tickers.ToList(),
                    FixedTickerIndex = 0,
                    LotsMax = 10,
                    LotsMin = 10,
                    TradeRandomTicker = false
                },
                TradeSets = new TradersSettings.TradeSettings
                {
                    MakersCount = 0,
                    OneShotTradersCount = 1,
                    ProbOfNewOrder = 70,
                    ProbOfMassCancel = 15,
                    ProbOfCancelOrder = 15,
                    ProbErrorRequest = 0
                },
                PayloadSets = new TradersSettings.PayloadSettings
                {
                    Mode = PayloadSettingsMode.Even,
                    RequestPerIterationProb = 90
                }
            };
            defaultSettings.CopyCommonSettingsToTarget(sets);
            var paySets = sets.PayloadSets;

            if (payload < 4)
            {
                paySets.TradersCount = payload * 10;
                paySets.SleepInterval = 20;
            }
            else
            {
                sets.TradeSets.OneShotTradersCount = 2;
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
            return $"{sets.PayloadSets.TradersCount} traders and {sets.TradeSets.OneShotTradersCount} \"one-shot traders\"\n" + 
                $"~ {reqPerSec:F1} requests per second";
        }
    }
}
