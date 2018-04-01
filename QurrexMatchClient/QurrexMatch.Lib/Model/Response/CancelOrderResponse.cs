using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Request;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Response
{
    /// <summary>
    /// a response on cancel order request
    /// succeeded or not
    /// </summary>
    public class CancelOrderResponse : BaseResponse, IOrigRequest
    {
        public static int StructSize;

        public UInt64 InputTime { get; set; }

        public UInt64 OutputTime { get; set; }

        public CancelOrderRequest OriginRequest { get; set; }

        public UInt64 SystemTime { get; set; }

        public Int64 AmountCancelled { get; set; }

        public Int64 AmountRest { get; set; }

        public CancelReason CancelReason { get; set; }

        static CancelOrderResponse()
        {
            CancelOrderResponse r = null;
            StructSize = CancelOrderRequest.StructSize +
                         PropInfo.GetSize(r, o => o.InputTime) +
                         PropInfo.GetSize(r, o => o.OutputTime) +
                         PropInfo.GetSize(r, o => o.SystemTime) +
                         PropInfo.GetSize(r, o => o.AmountCancelled) +
                         PropInfo.GetSize(r, o => o.AmountRest) +
                         1; // CancelReason
        }

        public override string ToString()
        {
            var reqData = OriginRequest == null ? "<null>" : $"#{OriginRequest.RequestId} {OriginRequest.OrderSide} #{OriginRequest.ExchangeOrderId} INSTR_{OriginRequest.InstrumentId}";
            return $"CancelOrderResponse: {reqData}, amt cancelled: {AmountCancelled}, amt rest {AmountRest}, reason: {CancelReason}";
        }

        public string GetOrigRequestId()
        {
            return OriginRequest?.OriginRequestId ?? "";
        }

        public static CancelOrderResponse ReadFromBuffer(MessageHeader frame, ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;

            var resp = new CancelOrderResponse();
            resp.OriginRequest = CancelOrderRequest.ReadFromBuffer(buf, offset);
            if (resp.OriginRequest == null) return null;
            offset += CancelOrderRequest.StructSize;

            resp.InputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.InputTime);

            resp.OutputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.OutputTime);

            resp.SystemTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.SystemTime);

            resp.AmountCancelled = BitConverter.ToInt32(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.AmountCancelled);

            resp.AmountRest = BitConverter.ToInt32(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.AmountRest);

            resp.CancelReason = (CancelReason) buf.data[offset++];
            return resp;
        }
    }
}
