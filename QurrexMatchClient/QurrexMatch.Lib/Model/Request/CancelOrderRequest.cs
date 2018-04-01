using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Request
{
    /// <summary>
    /// cancel placed order
    /// </summary>
    public class CancelOrderRequest : BaseRequest
    {
        public static readonly int StructSize;

        // 16
        public string ClearingAccountId { get; set; }

        // 16
        public string TraderAccountId { get; set; }

        public Int32 InstrumentId { get; set; }

        public Int64 ExchangeOrderId { get; set; }

        // 16
        public string OriginRequestId { get; set; }

        public OrderSide OrderSide { get; set; }

        static CancelOrderRequest()
        {
            CancelOrderRequest o = null;
            StructSize = 16 + // RequestId
                         16 + // ClearingAccountId
                         16 + // TraderAccountId
                         PropInfo.GetSize(o, r => r.InstrumentId) +
                         PropInfo.GetSize(o, r => r.ExchangeOrderId) +
                         16 + // OriginRequestId
                         1; // OrderSide
        }

        public override ByteBuffer Serialize()
        {
            var buf = new ByteBuffer(128);
            var frame = new MessageHeader
            {
                msgId = (Int16)MessageType.CancelOrderRequest,
                msgSeq = SessionId,
                msgSize = (UInt16)StructSize
            };
            frame.AppendToBuffer(buf);
            buf.AppendFixedString(RequestId, encoding, 16);
            buf.AppendFixedString(ClearingAccountId, encoding, 16);
            buf.AppendFixedString(TraderAccountId, encoding, 16);
            buf.AppendInt32(InstrumentId);
            buf.AppendInt64(ExchangeOrderId);
            buf.AppendFixedString(OriginRequestId, encoding, 16);
            buf.AppendByte((byte) OrderSide);
            return buf;
        }

        public static CancelOrderRequest ReadFromBuffer(ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;

            var req = new CancelOrderRequest();
            req.RequestId = encoding.GetString(buf.data, offset, 16).Trim((char) 0);
            offset += 16;

            req.ClearingAccountId = encoding.GetString(buf.data, offset, 16).Trim((char)0);
            offset += 16;

            req.TraderAccountId = encoding.GetString(buf.data, offset, 16).Trim((char)0);
            offset += 16;

            req.InstrumentId = BitConverter.ToInt32(buf.data, offset);
            offset += PropInfo.GetSize(req, r => r.InstrumentId);

            req.ExchangeOrderId = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(req, r => r.ExchangeOrderId);

            req.OriginRequestId = encoding.GetString(buf.data, offset, 16).Trim((char)0);
            offset += 16;

            req.OrderSide = (OrderSide) buf.data[offset++];
            req.TrimZeroSymbols();
            return req;
        }

        private void TrimZeroSymbols()
        {
            RequestId = TrimZeroSymbols(RequestId);
            ClearingAccountId = TrimZeroSymbols(ClearingAccountId);
            TraderAccountId = TrimZeroSymbols(TraderAccountId);
            OriginRequestId = TrimZeroSymbols(OriginRequestId);
        }
    }
}
