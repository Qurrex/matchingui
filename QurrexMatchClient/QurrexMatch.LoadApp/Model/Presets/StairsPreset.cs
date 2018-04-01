using System.Linq;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class StairsPreset : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public StairsPreset(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 8;
            Title = "Payload growing step by step";
            Description = "Payload changes step by step.\n" +
                          "Single instrument is traded, price remains untouched.\n" +
                          "Payload affects the number of \"takers\" and the interval between placing orders.";
        }

        public override TradersSettings Build(int payload)
        {
            var sets = new TradersSettings
            {
                PricingSets = new TradersSettings.PricingSettings
                {
                    PricingMode = PricingSettingsMode.Fixed
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
                    Mode = PayloadSettingsMode.Stairs,
                    RequestPerIterationProb = 100,
                    StepsCount = 8,
                    SecondsPerStep = 5
                }
            };
            defaultSettings.CopyCommonSettingsToTarget(sets);
            var paySets = sets.PayloadSets;

            if (payload < 4)
            {
                paySets.TradersCount = payload * 8;
                paySets.ConnectionsCount = payload * 2;
                paySets.SleepInterval = 20;
            }
            else if (payload < 7)
            {
                paySets.TradersCount = payload * 10;
                paySets.ConnectionsCount = payload * 3;
                paySets.SleepInterval = 7;
            }
            else
            {
                paySets.TradersCount = payload * 12;
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
