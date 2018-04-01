using System;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// one of trading instruments supported by the matching server
    /// </summary>
    public class Ticker
    {
        /// <summary>
        /// instrument's name, like "BTCUSD"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// instrument's numeric Id
        /// widely used on the the matching server instead of symbol names
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// instrument's reference or "default" price
        /// used, e.g., in FairPriceMaker
        /// </summary>
        public double DefaultPrice { get; set; }

        /// <summary>
        /// minimal trading volume allowed for a new order
        /// </summary>
        public double MinVolume { get; set; }

        /// <summary>
        /// a step for the trading price
        /// </summary>
        public double PriceStep { get; set; }

        /// <summary>
        /// helper method to round the order's price and make it integer out of float value,
        /// as the matching server demands
        /// </summary>
        public long RoundAndScalePrice(double price)
        {
            var steps = (int) Math.Round(price / PriceStep);
            price = steps * PriceStep;
            return (long)(price * 100000000);
        }

        /// <summary>
        /// the order's volume is scaled to be MinVolume + N*MinVolume
        /// </summary>
        public long RoundAndScaleVolume(double volume)
        {
            var steps = (int)Math.Round(volume / MinVolume);
            volume = steps * MinVolume;
            return (long)(volume * 100000000);
        }

        public decimal GetAbsPriceFromScaledM(long price)
        {
            return price / 100000000M;
        }

        public double GetAbsPriceFromScaledD(long price)
        {
            return price / 100000000.0;
        }
    }
}
