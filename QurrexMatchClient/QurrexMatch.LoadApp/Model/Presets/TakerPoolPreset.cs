using System.Linq;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class TakerPoolPreset : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public TakerPoolPreset(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 2;
            Title = "Takers' Pool";
            Description = "A simple case. The price is fixed, the payload does not change in time.\n" + 
                          "A number of \"takers\" who place order at the exact market price.\n" +
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
                    LotsMax = 10,
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
                    Mode = PayloadSettingsMode.Even,
                    RequestPerIterationProb = 100
                }
            };
            defaultSettings.CopyCommonSettingsToTarget(sets);
            var paySets = sets.PayloadSets;

            if (payload < 4)
            {
                paySets.TradersCount = payload * 10;
                paySets.ConnectionsCount = payload * 2;
                paySets.SleepInterval = 20;
            } else
            {
                paySets.TradersCount = payload * 10;
                paySets.ConnectionsCount = payload * 5;
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
