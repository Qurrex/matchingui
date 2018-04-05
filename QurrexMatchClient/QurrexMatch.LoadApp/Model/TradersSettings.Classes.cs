using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QurrexMatch.LoadApp.Model
{
    public partial class TradersSettings
    {
        /// <summary>
        /// payload settings: intervals between requests, threads count etc
        /// </summary>
        public class PayloadSettings
        {
            /// <summary>
            /// should the payload be constant or should it change by a sinusoid / by steps / by an exponent
            /// </summary>
            [JsonConverter(typeof(StringEnumConverter))]
            public PayloadSettingsMode Mode { get; set; } = PayloadSettingsMode.Even;

            /// <summary>
            /// count of threads sending requests by individual accounts
            /// </summary>
            public int TradersCount { get; set; } = 8;

            /// <summary>
            /// an interval between seding requests, mils
            /// </summary>
            public int SleepInterval { get; set; } = 100;

            /// <summary>
            /// a probability to make a trading request (or just do nothing) on each interval of time
            /// </summary>
            public decimal RequestPerIterationProb { get; set; } = 100;

            /// <summary>
            /// sinusoid period, mils - used when Mode = PayloadSettingsMode.Sinusoidal
            /// </summary>
            public int SinusoidPeriodMs { get; set; } = 1000 * 15;

            /// <summary>
            /// period for the payload grow from initial to target value
            /// Mode = PayloadSettingsMode.FadeIn
            /// </summary>
            public int FadingInSeconds { get; set; } = 15;

            /// <summary>
            /// Mode = PayloadSettingsMode.Stairs (StairsDown)
            /// seconds between the payload grows a bit higher
            /// </summary>
            public int SecondsPerStep { get; set; } = 2;

            /// <summary>
            /// Mode = PayloadSettingsMode.Stairs (StairsDown)
            /// count of steps for payload to grow up to its final value
            /// </summary>
            public int StepsCount { get; set; } = 10;
        }

        /// <summary>
        /// a set of rules describing how the "market" prices changes (if it does)
        /// </summary>
        public class PricingSettings
        {
            /// <summary>
            /// should the price change by a sinusoid or should it remain constant
            /// </summary>
            [JsonConverter(typeof(StringEnumConverter))]
            public PricingSettingsMode PricingMode { get; set; } = PricingSettingsMode.Fixed;

            /// <summary>
            /// used when PricingSettingsMode = Sinusoidal
            /// period, milliseconds
            /// </summary>
            public int SinusPeriodMs { get; set; } = 1000 * 60;

            /// <summary>
            /// used when PricingSettingsMode = Sinusoidal
            /// price changes withing [price - value/100%, price + value/100%]
            /// </summary>
            public decimal SinusAmplitudePercent { get; set; } = 1M;
        }

        /// <summary>
        /// several trading patterns are scripted here
        /// </summary>
        public class TradeSettings
        {
            /// <summary>
            /// probability of making a new order request
            /// </summary>
            public decimal ProbOfNewOrder { get; set; } = 55;

            /// <summary>
            /// probability of making an order cancel request
            /// </summary>
            public decimal ProbOfCancelOrder { get; set; } = 35;

            /// <summary>
            /// probability of making a mass-cancel request
            /// </summary>
            public decimal ProbOfMassCancel { get; set; } = 10;

            /// <summary>
            /// count of market-makers among the traders
            /// </summary>
            public int MakersCount { get; set; } = 1;

            /// <summary>
            /// traders who from time to time grab the whole order book
            /// </summary>
            public int OneShotTradersCount { get; set; } = 0;

            /// <summary>
            /// probability of making a mailformatting request
            /// </summary>
            public decimal ProbErrorRequest { get; set; } = 1;

            /// <summary>
            /// a fixed number of requests before a OneShotTrader grabs the order book
            /// </summary>
            public int RequestsBeforeGrabTheBook { get; set; } = 0;

            /// <summary>
            /// a probability with a OneShotTrader grabs the order book
            /// used if RequestsBeforeGrabTheBook = 0 only
            /// </summary>
            public decimal ProbOfGrabTheBook { get; set; } = 1.5M;

            /// <summary>
            /// time interval in which an MM updates orders
            /// </summary>
            public int MilisecondsBeforUpdateMMLevels { get; set; } = 1000;

            /// <summary>
            /// count of orders below and above the market price for a MM
            /// </summary>
            public int MarketLevelsCount { get; set; } = 5;

            /// <summary>
            /// lots per order for a MarketMaker
            /// </summary>
            public int MarketMakerOrderLots { get; set; } = 100;
        }

        /// <summary>
        /// a set of rules for calculating trading volume and choosing among the trading instruments
        /// </summary>
        public class MoneyManagementSettings
        {
            /// <summary>
            /// available trading instruments
            /// </summary>
            public List<Ticker> Tickers { get; set; } = new List<Ticker>();

            /// <summary>
            /// trade by one and the only instrument targeted by index within the Tickers list
            /// </summary>
            public int FixedTickerIndex { get; set; } = 0;

            /// <summary>
            /// should it trade random instrument
            /// </summary>
            public bool TradeRandomTicker { get; set; }

            /// <summary>
            /// minimum "lots" count for a new trade request
            /// </summary>
            public int LotsMin { get; set; } = 10;

            /// <summary>
            /// maximum "lots" count for a new trade request
            /// </summary>
            public int LotsMax { get; set; } = 10;

            /// <summary>
            /// a helper method for peeking a lot value
            /// </summary>
            public int MakeRandomLot(Random rand)
            {
                if (LotsMin == LotsMax) return LotsMin;
                return rand.Next(LotsMin, LotsMax);
            }
        }
    }
}
