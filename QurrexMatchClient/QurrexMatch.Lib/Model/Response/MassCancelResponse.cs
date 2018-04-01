using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Response
{
    public class MassCancelResponse : BaseResponse, IOrigRequest
    {
        public static readonly int StructSize;

        public UInt64 InputTime { get; set; }

        public UInt64 OutputTime { get; set; }

        public UInt64 Time { get; set; }

        // 16
        public string OriginRequestId { get; set; }

        // 16
        public string ClearingAccountId { get; set; }

        // 16
        public string TraderAccountId { get; set; }

        public Int32 InstrumentId { get; set; }

        public MassCancelMode CancelMode { get; set; }

        public MassCancelStatus CancelStatus { get; set; }

        public Int32 CancelledOrders { get; set; }

        static MassCancelResponse()
        {
            MassCancelResponse o = null;
            StructSize = PropInfo.GetSize(o, r => r.InputTime) +
                         PropInfo.GetSize(o, r => r.OutputTime) +
                         PropInfo.GetSize(o, r => r.Time) +
                         16 + // OriginRequestId
                         16 + // ClearingAccountId
                         16 + // TraderAccountId
                         PropInfo.GetSize(o, r => r.InstrumentId) +
                         1 + // CancelMode
                         1 + // CancelStatus
                         PropInfo.GetSize(o, r => r.CancelledOrders);
        }

        public override string ToString()
        {
            return $"Cancelled {CancelledOrders} orders @{Time.UInt64ToTime():yyyy.MM.dd HH:mm:ss.fff} by {InstrumentId}, {CancelStatus}";
        }

        public string GetOrigRequestId()
        {
            return OriginRequestId;
        }

        public static MassCancelResponse ReadFromBuffer(MessageHeader frame, ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;
            var resp = new MassCancelResponse();

            resp.InputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.InputTime);

            resp.OutputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.OutputTime);

            resp.Time = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.Time);

            resp.OriginRequestId = encoding.GetString(buf.data, offset, 16).Trim((char)0); ;
            offset += 16;

            resp.ClearingAccountId = encoding.GetString(buf.data, offset, 16).Trim((char)0); ;
            offset += 16;

            resp.TraderAccountId = encoding.GetString(buf.data, offset, 16).Trim((char)0); ;
            offset += 16;

            resp.InstrumentId = BitConverter.ToInt32(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.InstrumentId);

            resp.CancelMode = (MassCancelMode) buf.data[offset++];

            resp.CancelStatus = (MassCancelStatus) buf.data[offset++];

            resp.CancelledOrders = BitConverter.ToInt32(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.CancelledOrders);

            return resp;
        }
    }
}
