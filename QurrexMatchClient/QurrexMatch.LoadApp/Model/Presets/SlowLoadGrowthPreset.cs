using System.Linq;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class SlowLoadGrowthPreset : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public SlowLoadGrowthPreset(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 7;
            Title = "Slowly growing payload";
            Description = "The price is sinusoidal, the payload grows in time to its maximum value.\n" +
                          "A number of \"takers\" grows is a constant," +
                          "but intervals between placing orders slowly shortens in time";
        }

        public override TradersSettings Build(int payload)
        {
            var sets = new TradersSettings
            {
                PricingSets = new TradersSettings.PricingSettings
                {
                    PricingMode = PricingSettingsMode.Sinusoidal,
                    SinusPeriodMs = 2,
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
                    ProbErrorRequest = 5
                },
                PayloadSets = new TradersSettings.PayloadSettings
                {
                    Mode = PayloadSettingsMode.FadeIn,
                    FadingInSeconds = 60,
                    RequestPerIterationProb = 100
                }
            };
            defaultSettings.CopyCommonSettingsToTarget(sets);
            var paySets = sets.PayloadSets;

            if (payload < 4)
            {
                paySets.TradersCount = payload * 15;
                paySets.ConnectionsCount = payload * 4;
                paySets.SleepInterval = 20;
            }
            else
            {
                paySets.TradersCount = payload * 18;
                paySets.ConnectionsCount = payload * 6;
                paySets.SleepInterval = 5;
            }

            return sets;
        }

        public override string MakeDescription(int payload)
        {
            var sets = Build(payload);
            var reqPerSec = sets.PayloadSets.TradersCount * 1000M / (sets.PayloadSets.SleepInterval + 1) *
                            sets.PayloadSets.RequestPerIterationProb / 100M;
            return $"{sets.PayloadSets.TradersCount} \"takers\" sharing {sets.PayloadSets.ConnectionsCount} connections.\n" +
                $"~ {reqPerSec:F1} requests per second";
        }
    }
}
