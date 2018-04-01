using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Response.ExecReport
{
    /// <summary>
    /// a deal made by the server when two orders match
    /// </summary>
    public class Deal
    {
        public static readonly int StructSize;

        public Int64 DealId { get; set; }

        public Int64 Price { get; set; }

        public Int64 Amount { get; set; }

        static Deal()
        {
            Deal d = null;
            StructSize = PropInfo.GetSize(d, o => o.DealId) +
                         PropInfo.GetSize(d, o => o.Price) +
                         PropInfo.GetSize(d, o => o.Amount);
        }

        public override string ToString()
        {
            return $"#{DealId} - {Amount} @ {Price}";
        }

        public static Deal ReadFromBuffer(ByteBuffer buf, int offset = 0)
        {
            var d = new Deal();
            if (buf.length - offset < StructSize)
                return d;
            d.DealId = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(d, r => r.DealId);

            d.Price = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(d, r => r.Price);

            d.Amount = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(d, r => r.Amount);

            return d;
        }
    }
}
