using System;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.Request;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// here market-maker strategy is implemented:
    /// from time to time the market-maker places large orders - a number of
    /// orders above the "fair" market price, a number of orders below the price
    /// old and unfilled orders are being cancelled
    /// </summary>
    public partial class Trader
    {
        /// <summary>
        /// used to skip some time before placing new orders
        /// </summary>
        private DateTime lastTimeMMordersUpdated = DateTime.Today;

        /// <summary>
        /// decide on updating the orders
        /// </summary>
        public void ActAsMarketMaker()
        {
            var milsPassed = (DateTime.Now - lastTimeMMordersUpdated).TotalMilliseconds;
            if (milsPassed < settings.TradeSets.MilisecondsBeforUpdateMMLevels) return;

            try
            {
                foreach (var ticker in settings.MoneyManagementSets.Tickers)
                    DoActAsMarketMaker(ticker);
            }
            catch (Exception e)
            {
                logMessage($"Error updating MM orders: {e.GetType().Name} {e.Message}", LoggingLevel.Error);
            }
            finally
            {
                lastTimeMMordersUpdated = DateTime.Now;
            }
        }

        /// <summary>
        /// cancel old orders and place the new ones
        /// </summary>
        private void DoActAsMarketMaker(Ticker ticker)
        {
            // cancel all the previous orders
            SendMassCancelRequest(ticker.Id);

            // place new orders
            var sides = new[] {OrderSide.Buy, OrderSide.Sell};
            foreach (var side in sides)
            {
                var sign = side == OrderSide.Buy ? 1 : -1;
                var priceBase = priceMaker.GetFairPrice(ticker.Id, side, settings.PricingSets);
                for (var i = 0; i < settings.TradeSets.MarketLevelsCount; i++)
                {
                    var price = priceBase + sign * i * ticker.PriceStep;
                    var priceRounded = ticker.RoundAndScalePrice(price);
                    var volume = ticker.RoundAndScaleVolume(ticker.MinVolume * settings.TradeSets.MarketMakerOrderLots);
                    var req = new OrderRequest
                    {
                        AutoCancel = AutoCancel.ON,
                        OrderType = OrderType.LIMIT,
                        TimeInForce = TimeInForce.GTK,
                        ClearingAccountId = ClearingAccountId,
                        TraderAccountId = AccountId,
                        Flags = 0,
                        InstrumentId = ticker.Id,
                        Comment = "MM",
                        OrderSide = side,
                        Price = priceRounded,
                        Amount = volume
                    };

                    SendNewOrderRequest(req);
                }
            }
        }
    }
}
