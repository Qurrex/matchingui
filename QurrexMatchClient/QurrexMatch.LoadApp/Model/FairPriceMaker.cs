using System;
using System.Collections.Generic;
using System.Linq;
using QurrexMatch.Lib.Model.Enumerations;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// a helper class that stores a "fair" price by
    /// each trading instrument
    /// or calculates a "fair" price using Math.Sin() function
    /// 
    /// used by the Trader class, shared among the trading threads
    /// </summary>
    public class FairPriceMaker
    {
        /// <summary>
        /// price range stored per instrument
        /// </summary>
        class HighLowPrice
        {
            public double highestPrice;

            public double lowestPrice;

            public double defaultPrice;
        }

        /// <summary>
        /// the highest and the lowest price by instrument
        /// used in some trading strategies
        /// </summary>
        private readonly Dictionary<int, HighLowPrice> highLowPriceByTicker;

        public FairPriceMaker(TradersSettings settings)
        {
            highLowPriceByTicker =
                settings.MoneyManagementSets.Tickers.ToDictionary(t => t.Id, t => new HighLowPrice { defaultPrice = t.DefaultPrice });
        }

        /// <summary>
        /// get a "fair" market price for a trader to
        /// </summary>
        /// <param name="tickerId">trading instrument referenced by Id</param>
        /// <param name="side">buy or sell</param>
        /// <param name="priceMode">pricing strategy</param>
        /// <returns>"fair" price</returns>
        public double GetFairPrice(int tickerId, OrderSide side, TradersSettings.PricingSettings priceMode)
        {
            var hl = highLowPriceByTicker[tickerId];
            if (priceMode.PricingMode == PricingSettingsMode.Fixed)
                return hl.defaultPrice;

            if (priceMode.PricingMode == PricingSettingsMode.Sinusoidal)
            {
                var ticks = DateTime.Now.Ticks / priceMode.SinusPeriodMs;
                var price = hl.defaultPrice * (1 + (float)priceMode.SinusAmplitudePercent / 100f * Math.Sin(ticks));
                hl.highestPrice = Math.Max(price, hl.highestPrice);
                hl.lowestPrice = Math.Min(price, hl.lowestPrice);
                return price;
            }

            return hl.defaultPrice;
        }

        /// <summary>
        /// used by the Trader class in some trading strategies
        /// </summary>
        public double GetHighestPrice(int tickerId) => GetHighOrLowPrice(tickerId, true);

        /// <summary>
        /// also used by the Trader class in some trading strategies
        /// </summary>
        public double GetLowestPrice(int tickerId) => GetHighOrLowPrice(tickerId, false);

        /// <summary>
        /// used in both GetHighestPrice and GetLowestPrice
        /// </summary>
        private double GetHighOrLowPrice(int tickerId, bool getHigh)
        {
            var hl = highLowPriceByTicker[tickerId];
            var price = getHigh ? hl.highestPrice : hl.lowestPrice;
            return price == 0 ? hl.defaultPrice : price;
        }
    }
}
