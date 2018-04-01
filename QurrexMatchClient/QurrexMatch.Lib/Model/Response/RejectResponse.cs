using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Response
{
    /// <summary>
    /// a response sent when the server declines the order
    /// </summary>
    public class RejectResponse : BaseResponse, IOrigRequest
    {
        public static readonly int StructSize;

        public UInt64 InputTime { get; set; }

        public UInt64 OutputTime { get; set; }

        public UInt64 Time { get; set; }

        public string RequestId { get; set; }

        public Int16 ErrorCodeInternal { get; set; }

        public ErrorCode ErrorCode => (ErrorCode) ErrorCodeInternal;

        static RejectResponse()
        {
            RejectResponse r = null;
            StructSize = PropInfo.GetSize(r, o => o.InputTime) +
                         PropInfo.GetSize(r, o => o.OutputTime) +
                         PropInfo.GetSize(r, o => o.Time) +
                         16 + // RequestId
                         PropInfo.GetSize(r, o => o.ErrorCodeInternal);
        }

        public override string ToString()
        {
            return $"Rejected: {ErrorCode} @{Time.UInt64ToTime():yyyy.MM.dd HH:mm:ss.fff}, #{RequestId}";
        }

        public string GetOrigRequestId()
        {
            return RequestId;
        }

        public static RejectResponse ReadFromBuffer(MessageHeader frame, ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;            
            var resp = new RejectResponse();

            resp.InputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.InputTime);

            resp.OutputTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.OutputTime);

            resp.Time = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(resp, o => o.Time);

            resp.RequestId = encoding.GetString(buf.data, offset, 16).Trim((char)0);
            offset += 16;

            resp.ErrorCodeInternal = BitConverter.ToInt16(buf.data, offset);

            return resp;
        }
    }
}
