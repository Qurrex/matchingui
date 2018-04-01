using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Request
{
    /// <summary>
    /// a request to cancel all the placed orders
    /// </summary>
    public class MassCancelRequest : BaseRequest
    {
        public static readonly int StructSize;

        // 16
        public string ClearingAccountId { get; set; }

        // 16
        public string TraderAccountId { get; set; }

        public Int32 InstrumentId { get; set; }

        public MassCancelMode CancelMode { get; set; }

        static MassCancelRequest()
        {
            MassCancelRequest o = null;
            StructSize = 16 + // RequestId
                         16 + // ClearingAccountId
                         16 + // TraderAccountId
                         PropInfo.GetSize(o, r => r.InstrumentId) +                        
                         1; // CancelMode
        }

        public override ByteBuffer Serialize()
        {
            var buf = new ByteBuffer(128);
            var frame = new MessageHeader
            {
                msgId = (Int16)MessageType.MassCancelRequest,
                msgSeq = SessionId,
                msgSize = (UInt16)StructSize
            };
            frame.AppendToBuffer(buf);
            buf.AppendFixedString(RequestId, encoding, 16);
            buf.AppendFixedString(ClearingAccountId, encoding, 16);
            buf.AppendFixedString(TraderAccountId, encoding, 16);
            buf.AppendInt32(InstrumentId);
            buf.AppendByte((byte)CancelMode);
            return buf;
        }
    }
}
