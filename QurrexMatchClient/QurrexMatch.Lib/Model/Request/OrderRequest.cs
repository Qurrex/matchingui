using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Request
{
    /// <summary>
    /// place new order
    /// </summary>
    public class OrderRequest : BaseRequest
    {
        public static readonly int StructSize;

        // 16
        public string ClearingAccountId { get; set; }

        // 16
        public string TraderAccountId { get; set; }

        public Int32 InstrumentId { get; set; }

        public OrderType OrderType { get; set; } = OrderType.LIMIT;

        public TimeInForce TimeInForce { get; set; } = TimeInForce.GTK;

        public OrderSide OrderSide { get; set; } = OrderSide.Buy;

        public AutoCancel AutoCancel { get; set; } = AutoCancel.ON;

        public Int64 Amount { get; set; }

        public Int64 Price { get; set; }

        public UInt64 Flags { get; set; }

        // 16
        public string Comment { get; set; }

        static OrderRequest()
        {
            OrderRequest r = null;
            StructSize =
                16 // RequestId
                + 16 // ClearingAccountId
                + 16 // TraderAccountId
                + PropInfo.GetSize(r, o => o.InstrumentId)
                + sizeof(byte) // OrderType
                + sizeof(byte) // TimeInForce
                + sizeof(byte) // OrderSide
                + sizeof(byte) // AutoCancel
                + PropInfo.GetSize(r, o => o.Amount)
                + PropInfo.GetSize(r, o => o.Price)
                + PropInfo.GetSize(r, o => o.Flags)
                + 16; // comment
        }

        public override string ToString()
        {
            return $"#{RequestId} - {OrderSide} {Amount} INST_{InstrumentId} @{Price}";
        }

        public override ByteBuffer Serialize()
        {
            var buf = new ByteBuffer(256);
            var frame = new MessageHeader
            {
                msgId = (Int16) MessageType.NewOrderBody,
                msgSeq = SessionId,
                msgSize = (UInt16) StructSize
            };
            frame.AppendToBuffer(buf);
            buf.AppendFixedString(RequestId, encoding, 16);
            buf.AppendFixedString(ClearingAccountId, encoding, 16);
            buf.AppendFixedString(TraderAccountId, encoding, 16);
            buf.AppendInt32(InstrumentId);

            buf.AppendByte((byte)OrderType);
            buf.AppendByte((byte)TimeInForce);
            buf.AppendByte((byte)OrderSide);
            buf.AppendByte((byte)AutoCancel);

            buf.AppendInt64(Amount);
            buf.AppendInt64(Price);
            buf.AppendUint64(Flags);

            buf.AppendFixedString(Comment, encoding, 16);
            return buf;
        }

        public static OrderRequest ReadFromBuffer(ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;

            var req = new OrderRequest();
            req.RequestId = encoding.GetString(buf.data, offset, 16).TrimEnd((char)0);
            offset += 16;

            req.ClearingAccountId = encoding.GetString(buf.data, offset, 16).TrimEnd((char)0);
            offset += 16;

            req.TraderAccountId = encoding.GetString(buf.data, offset, 16).TrimEnd((char)0);
            offset += 16;

            req.InstrumentId = BitConverter.ToInt32(buf.data, offset);
            offset += PropInfo.GetSize(req, r => r.InstrumentId);

            req.OrderType = (OrderType) buf.data[offset++];
            req.TimeInForce = (TimeInForce) buf.data[offset++];
            req.OrderSide = (OrderSide) buf.data[offset++];
            req.AutoCancel = (AutoCancel) buf.data[offset++];

            req.Amount = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(req, r => r.Amount);

            req.Price = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(req, r => r.Price);

            req.Flags = BitConverter.ToUInt64(buf.data, offset);

            return req;
        }
    }
}


/*
    static constexpr int msg_const_id = 1;
    TRequestID client_request_id;
    char clearing_account_id [16];
    char trader_account_id [16];
    int instrument_id;
    OrderType order_type;
    TimeInForce time_in_force;
    OrderSide order_side;
    AutoCancel auto_cancel;
    numeric::TPrice amount;
    numeric::TPrice price;
    int64_t flags;
    char comment [16];
*/
