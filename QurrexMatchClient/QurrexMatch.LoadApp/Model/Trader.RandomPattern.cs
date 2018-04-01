using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.Request;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// here are the methods to place random trading requests
    /// </summary>
    public partial class Trader
    {
        /// <summary>
        /// make a trading request - new order,cancel order or mass cancel
        /// or just skip this time
        /// </summary>
        public void TradeRandom()
        {
            var dice = rand.Next(0, 100);
            if (dice < settings.TradeSets.ProbOfNewOrder)
                SendNewOrderRequest();
            else if (dice < settings.TradeSets.ProbOfNewOrder + settings.TradeSets.ProbOfCancelOrder)
                SendCancelRequest();
            else SendMassRequest();
        }

        /// <summary>
        /// place a new order request
        /// </summary>
        private void SendNewOrderRequest()
        {
            var tickerIndex = settings.MoneyManagementSets.TradeRandomTicker
                ? rand.Next(settings.MoneyManagementSets.Tickers.Count)
                : settings.MoneyManagementSets.FixedTickerIndex;
            var ticker = settings.MoneyManagementSets.Tickers[tickerIndex];
            var req = new OrderRequest
            {
                AutoCancel = AutoCancel.ON,
                OrderType = OrderType.LIMIT,
                ClearingAccountId = ClearingAccountId,
                TraderAccountId = AccountId,
                Flags = 0,
                InstrumentId = ticker.Id,
                Comment = "market req",
                OrderSide = ThroughDice() < 50 ? OrderSide.Buy : OrderSide.Sell
            };
            CalculateOrderPrice(ticker, req);

            //var dice = ThroughDice();
            var timeInForce = TimeInForce.GTK; // dice < 33 ? TimeInForce.FOK : dice < 66 ? TimeInForce.GTK : TimeInForce.IOC;
            req.TimeInForce = timeInForce;

            var lot = settings.MoneyManagementSets.MakeRandomLot(rand);
            var amount = ticker.RoundAndScaleVolume(ticker.MinVolume * lot);
            // make a bad request?
            if (ThroughDice() < settings.TradeSets.ProbErrorRequest)
                amount = 0;
            req.Amount = amount;
            SendNewOrderRequest(req);
        }

        /// <summary>
        /// place a cancel order request
        /// </summary>
        private void SendCancelRequest()
        {
            // find a response from server - a confirmed order
            var resp = orderResponses.PopRandomResponse();
            if (resp?.OriginRequest == null)
                return; // no response found, have no order to cancel
            SendCancelOrderRequest(new CancelOrderRequest
            {
                OrderSide = resp.OriginRequest.OrderSide,
                InstrumentId = resp.OriginRequest.InstrumentId,
                ClearingAccountId = ClearingAccountId,
                TraderAccountId = AccountId,
                ExchangeOrderId = resp.ExchangeOrderId,
                OriginRequestId = resp.OriginRequest.RequestId
            });
        }

        /// <summary>
        /// cancel all the orders placed in one "broadcast" request
        /// </summary>
        private void SendMassRequest()
        {
            var tickerIndex = settings.MoneyManagementSets.TradeRandomTicker
                ? rand.Next(settings.MoneyManagementSets.Tickers.Count)
                : settings.MoneyManagementSets.FixedTickerIndex;
            var tickerId = settings.MoneyManagementSets.Tickers[tickerIndex].Id;
            try
            {
                SendMassCancelRequest(tickerId);
            }
            catch
            {
                statistics.IncrementSendRequestErrorCount();
            }
        }

        /// <summary>
        /// calculate price for an order being placed
        /// </summary>
        private void CalculateOrderPrice(Ticker ticker, OrderRequest req)
        {
            var marketPrice = priceMaker.GetFairPrice(ticker.Id, req.OrderSide, settings.PricingSets);
            req.Price = ticker.RoundAndScalePrice(marketPrice);
        }

        /// <summary>
        /// a random-helper-method, deals with probability 0 .. 100%
        /// </summary>
        private decimal ThroughDice()
        {
            return rand.Next(0, 100 * 10000) / 10000M;
        }        
    }
}
