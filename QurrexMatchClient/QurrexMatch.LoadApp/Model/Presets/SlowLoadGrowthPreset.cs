﻿using System.Linq;

namespace QurrexMatch.LoadApp.Model.Presets
{
    public class SlowLoadGrowthPreset : SettingsPreset
    {
        private readonly TradersSettings defaultSettings;

        public SlowLoadGrowthPreset(TradersSettings defaultSettings)
        {
            this.defaultSettings = defaultSettings;
            ImageIndex = 7;
            Title = "Changing the price and growing the Load level";
            Description = "A number of traders grows constantly" +
                          "but intervals between placing orders slowly shorten in time.\n\n"+
                          "The price changes according to the sinusoid.\n" +
                          "The Load level grows to the maximum value.\n" +
                          "Load level settings affect the maximum number of traders (threads) and the minimum interval between placing orders.";
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
                paySets.SleepInterval = 20;
            }
            else
            {
                paySets.TradersCount = payload * 18;
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
