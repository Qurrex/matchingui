using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Request;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Response
{
    /// <summary>
    /// a response on order's placing
    /// a separate response (ExecutionReport) will be sent
    /// when this order is matched
    /// </summary>
    public class OrderResponse : BaseResponse, IOrigRequest
    {
        public static int StructSize;

        public UInt64 InputTime { get; set; }

        public UInt64 OutputTime { get; set; }

        public OrderRequest OriginRequest { get; set; }

        public UInt64 SystemTime { get; set; }

        public Int64 ExchangeOrderId { get; set; }

        public Int16 LiquidityPoolId { get; set; }

        public Int16 OrderRoutingRule { get; set; }

        static OrderResponse()
        {
            OrderResponse r = null;
            StructSize = OrderRequest.StructSize +
                         PropInfo.GetSize(r, o => o.InputTime) +
                         PropInfo.GetSize(r, o => o.OutputTime) +
                         PropInfo.GetSize(r, o => o.SystemTime) +
                         PropInfo.GetSize(r, o => o.ExchangeOrderId) +
                         PropInfo.GetSize(r, o => o.LiquidityPoolId) +
                         PropInfo.GetSize(r, o => o.OrderRoutingRule);
        }

        public override string ToString()
        {
            var reqData = OriginRequest == null ? "<null>" : $"#{OriginRequest.RequestId} {OriginRequest.OrderSide} {OriginRequest.Amount} INSTR_{OriginRequest.InstrumentId} @{OriginRequest.Price}";
            return $"OrderResponse: {reqData}, resulted order: {ExchangeOrderId}, pool {LiquidityPoolId}, time: {SystemTime.UInt64ToTime():yyyy.MM.dd HH:mm:ss.fff}";
        }

        public string GetOrigRequestId()
        {
            return OriginRequest?.RequestId ?? "";
        }

        public static OrderResponse ReadFromBuffer(MessageHeader frame, ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;
            var resp = new OrderResponse();

            resp.InputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.InputTime);

            resp.OutputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.OutputTime);

            resp.OriginRequest = OrderRequest.ReadFromBuffer(buf, offset);
            if (resp.OriginRequest == null) return null;
            offset += OrderRequest.StructSize;

            resp.SystemTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.SystemTime);

            resp.ExchangeOrderId = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.ExchangeOrderId);

            resp.LiquidityPoolId = BitConverter.ToInt16(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.LiquidityPoolId);

            resp.OrderRoutingRule = BitConverter.ToInt16(buf.data, offset);

            return resp;
        }
    }
}
