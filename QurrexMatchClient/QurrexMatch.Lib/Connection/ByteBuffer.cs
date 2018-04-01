using System;
using System.Linq;
using System.Text;

namespace QurrexMatch.Lib.Connection
{
    /// <summary>
    /// class holds bytes, reads and appends
    /// used in TCP connection
    /// </summary>
    public class ByteBuffer
    {
        public byte[] data;

        public int length;

        private readonly int defaultLength;

        public ByteBuffer(int defaultLength)
        {
            this.defaultLength = defaultLength;
            data = new byte[defaultLength];
        }

        public void Append(ByteBuffer buf, int offset = 0)
        {
            Append(buf.data, buf.length, offset);
        }

        public void Append(byte[] buf, int bufLen, int offset = 0)
        {
            if (bufLen + length <= data.Length)
            {
                Array.Copy(buf, offset, data, length, bufLen - offset);
                length += bufLen - offset;
                return;
            }
            var newData = new byte[length + bufLen - offset + defaultLength];
            data.CopyTo(newData, 0);
            Array.Copy(buf, offset, newData, length, bufLen - offset);
            length += bufLen - offset;
            data = newData;
        }

        public void AppendInt16(Int16 val)
        {
            var bytes = BitConverter.GetBytes(val);
            bytes.CopyTo(data, length);
            length += bytes.Length;
        }

        public void AppendUInt16(UInt16 val)
        {
            var bytes = BitConverter.GetBytes(val);
            bytes.CopyTo(data, length);
            length += bytes.Length;
        }

        public void AppendInt32(Int32 val)
        {
            var bytes = BitConverter.GetBytes(val);
            bytes.CopyTo(data, length);
            length += bytes.Length;
        }

        public void AppendInt64(Int64 val)
        {
            var bytes = BitConverter.GetBytes(val);
            bytes.CopyTo(data, length);
            length += bytes.Length;
        }

        public void AppendUint64(UInt64 val)
        {
            var bytes = BitConverter.GetBytes(val);
            bytes.CopyTo(data, length);
            length += bytes.Length;
        }

        public void AppendByte(byte val)
        {
            data[length] = val;
            length++;
        }

        public void AppendString(string s, Encoding encoding)
        {
            var bytes = encoding.GetBytes(s);
            bytes.CopyTo(data, length);
            length += bytes.Length;
        }

        public void AppendFixedString(string s, Encoding encoding, int bytesCount)
        {
            var bytes = encoding.GetBytes(s);
            for (var i = 0; i < bytesCount; i++)
            {
                var b = bytes.Length > i ? bytes[i] : (byte)0;
                data[length++] = b;
            }
        }

        public void Clear()
        {
            length = 0;
        }

        public void CutFromBegin(int bytesCount)
        {
            var size = Math.Max(length - bytesCount, defaultLength);
            var newData = new byte[size];
            Array.Copy(data, 0, newData, 0, length - bytesCount);
            data = newData;
            length -= bytesCount;
        }

        public string ToString(Encoding encoding)
        {
            return encoding.GetString(data, 0, length);
        }

        public string ToHexString()
        {
            return string.Join("", data.Take(length).Select(d => d.ToString("X2")));
        }
    }
}
