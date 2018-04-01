using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model
{
    public class MessageHeader
    {
        public static readonly int StructSize;

        public Int16 msgId;

        public UInt16 msgSize;

        public Int64 msgSeq;

        static MessageHeader()
        {
            MessageHeader f = null;
            StructSize =
                PropInfo.GetSize(f, r => r.msgId) +
                PropInfo.GetSize(f, r => r.msgSize) +
                PropInfo.GetSize(f, r => r.msgSeq);
        }

        public void AppendToBuffer(ByteBuffer buf)
        {
            buf.AppendInt16(msgId);
            buf.AppendUInt16(msgSize);
            buf.AppendInt64(msgSeq);
        }

        public static MessageHeader ReadFromBuffer(ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < StructSize) return null;
            MessageHeader f = null;
            var frame = new MessageHeader
            {
                msgId = BitConverter.ToInt16(buf.data, offset),
                msgSize = BitConverter.ToUInt16(buf.data, offset + PropInfo.GetSize(f, r => r.msgId)),
                msgSeq = BitConverter.ToInt64(buf.data, offset + PropInfo.GetSize(f, r => r.msgId) + 
                    PropInfo.GetSize(f, r => r.msgSize))
            };
            return frame;
        }
    }
}
