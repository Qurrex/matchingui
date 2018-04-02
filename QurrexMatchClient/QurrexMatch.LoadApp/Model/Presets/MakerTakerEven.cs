using System.Linq;
using QurrexMatch.Lib.Model.Enumerations;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class MakerTakerEven : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public MakerTakerEven(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 3;
            Title = "Maker / Taker";
            Description = "Another simple case. The price is fixed, the payload does not change in time.\n" +
                          "A number of \"takers\" who place order at the exact market price\n" +
                          "deal with one or two market makers." +
                          "Payload affects mostly the number of \"takers\" and the interval between placing orders.";
        }

        public override TradersSettings Build(int payload)
        {
            var sets = new TradersSettings
            {
                PricingSets = new TradersSettings.PricingSettings
                {
                    PricingMode = PricingSettingsMode.Sinusoidal,
                    SinusAmplitudePercent = 1.5m,
                    SinusPeriodMs = 1000 * 10
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
                    MakersCount = 1,
                    OneShotTradersCount = 0,
                    ProbOfNewOrder = 70,
                    ProbOfMassCancel = 15,
                    ProbOfCancelOrder = 15,
                    ProbErrorRequest = 5,
                    MarketMakerOrderLots = 200,
                    MarketLevelsCount = 4,
                    MilisecondsBeforUpdateMMLevels = 1000
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
                paySets.TradersCount = payload * 5;
                paySets.ConnectionsCount = payload * 2;
                paySets.SleepInterval = 30;
            }
            else
            {
                sets.TradeSets.MakersCount = 2;
                paySets.TradersCount = payload * 10;
                paySets.ConnectionsCount = payload * 6;
                paySets.SleepInterval = 7;
            }

            return sets;
        }

        public override string MakeDescription(int payload)
        {
            var sets = Build(payload);
            var reqPerSecTakers = (sets.PayloadSets.TradersCount - sets.TradeSets.MakersCount) * 1000M /
                                  (sets.PayloadSets.SleepInterval + 1) *
                                  sets.PayloadSets.RequestPerIterationProb / 100M;
            var makersReq = sets.TradeSets.MakersCount * (2 * sets.TradeSets.MarketLevelsCount *
                                                          1000M / sets.TradeSets.MilisecondsBeforUpdateMMLevels);
            var rps = reqPerSecTakers + makersReq;

            var makersStr = sets.TradeSets.MakersCount > 1 ? "makers" : "maker";
            return $"{sets.PayloadSets.TradersCount} \"takers\" and {sets.TradeSets.MakersCount} {makersStr} " + 
                $"sharing {sets.PayloadSets.ConnectionsCount} connections.\n" +
                $"~ {rps:F1} requests per second";
        }
    }
}
