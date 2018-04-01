using System;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.Lib.Model.Response.ExecReport
{
    /// <summary>
    /// a deal or a series of deals, made of two orders
    /// when these orders are met by server 
    /// </summary>
    public class ExecReportBody
    {
        public const int DealsSize = 10;

        public UInt64 SystemTime { get; set; }

        public Int64 ExchangeOrderId { get; set; }

        public Int64 AmountRest { get; set; }

        public byte DealsCount { get; set; }

        public Deal[] Deals { get; set; } = new Deal[DealsSize];

        public override string ToString()
        {
            return $"Order #{ExchangeOrderId}, unfilled {AmountRest}, {DealsCount} deals";
        }

        public static ExecReportBody ReadFromBuffer(ByteBuffer buf, int offset = 0)
        {
            var d = new ExecReportBody();
            d.SystemTime = BitConverter.ToUInt64(buf.data, offset);
            offset += PropInfo.GetSize(d, r => r.SystemTime);

            d.ExchangeOrderId = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(d, r => r.ExchangeOrderId);

            d.AmountRest = BitConverter.ToInt64(buf.data, offset);
            offset += PropInfo.GetSize(d, r => r.AmountRest);

            d.DealsCount = buf.data[offset++];

            if (d.DealsCount > d.Deals.Length) d.Deals = new Deal[d.DealsCount];

            for (var i = 0; i < d.DealsCount; i++)
            {
                var deal = Deal.ReadFromBuffer(buf, offset);
                if (deal == null) break;
                d.Deals[i] = deal;
                offset += Deal.StructSize;
            }
            return d;
        }
    }
}
