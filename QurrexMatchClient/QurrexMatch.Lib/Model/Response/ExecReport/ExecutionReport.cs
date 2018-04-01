using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Request;

namespace QurrexMatch.Lib.Model.Response.ExecReport
{
    public class ExecutionReport : BaseResponse
    {
        public OrderRequest OriginRequest { get; set; }

        public ExecReportBody ExecReport { get; set; }

        public override string ToString()
        {
            var reqStr = OriginRequest == null ? "<null>" : OriginRequest.ToString();
            var reportStr = ExecReport == null ? "<null>" : ExecReport.ToString();
            return $"request: {reqStr}, report: {reportStr}";
        }

        public static ExecutionReport ReadFromBuffer(MessageHeader frame, ByteBuffer buf, int offset = 0)
        {
            if (buf.length - offset < OrderRequest.StructSize) return null;
            var orig = OrderRequest.ReadFromBuffer(buf, offset);
            if (orig == null) return null;
            offset += OrderRequest.StructSize;

            var rep = ExecReportBody.ReadFromBuffer(buf, offset);
            return rep == null
                ? null
                : new ExecutionReport
                {
                    OriginRequest = orig,
                    ExecReport = rep
                };
        }
    }
}
