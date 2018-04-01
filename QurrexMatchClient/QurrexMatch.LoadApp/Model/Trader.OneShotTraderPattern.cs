using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.Request;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// here is the one-shot trading strategy is implemented
    /// (a trader who sometimes places a large order below (or above) the "fair price")
    /// </summary>
    public partial class Trader
    {
        /// <summary>
        /// a counter for taking the decision to place an order
        /// </summary>
        private int requestsPassedToGrabTheBook;

        /// <summary>
        /// through dice and make a decision to "grab" the whole order book
        /// </summary>
        private void TryTakeTheBook()
        {
            if (settings.TradeSets.RequestsBeforeGrabTheBook > 0)
            {
                if (requestsPassedToGrabTheBook++ < settings.TradeSets.RequestsBeforeGrabTheBook)
                    return;
                requestsPassedToGrabTheBook = 0;
                TakeTheBook();
                return;
            }

            if (ThroughDice() < settings.TradeSets.ProbOfGrabTheBook)
                TakeTheBook();
        }

        /// <summary>
        /// place a large order below or above the "fair" market price
        /// </summary>
        private void TakeTheBook()
        {
            var tickerIndex = settings.MoneyManagementSets.TradeRandomTicker
                ? rand.Next(settings.MoneyManagementSets.Tickers.Count)
                : settings.MoneyManagementSets.FixedTickerIndex;
            var ticker = settings.MoneyManagementSets.Tickers[tickerIndex];
            var side = ThroughDice() < 50 ? OrderSide.Buy : OrderSide.Sell;
            var price = side == OrderSide.Buy
                ? priceMaker.GetLowestPrice(ticker.Id)
                : priceMaker.GetHighestPrice(ticker.Id);

            var lot = settings.MoneyManagementSets.LotsMax * 20;
            var amount = ticker.RoundAndScaleVolume(ticker.MinVolume * lot);

            var req = new OrderRequest
            {
                AutoCancel = AutoCancel.ON,
                OrderType = OrderType.LIMIT,
                ClearingAccountId = ClearingAccountId,
                TraderAccountId = AccountId,
                Flags = 0,
                InstrumentId = ticker.Id,
                Comment = "take the book",
                OrderSide = side,
                Price = ticker.RoundAndScalePrice(price),
                TimeInForce = TimeInForce.GTK,
                Amount = amount
            };
            SendNewOrderRequest(req);
        }
    }
}
