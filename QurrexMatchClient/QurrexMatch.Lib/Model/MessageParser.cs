using System;
using System.Collections.Generic;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Response;
using QurrexMatch.Lib.Model.Response.ExecReport;

namespace QurrexMatch.Lib.Model
{
    /// <summary>
    /// class deserilalizes server messages from bytes to typed objects
    /// </summary>
    public partial class MessageParser
    {
        /// <summary>
        /// messages parsed count, the key is type
        /// </summary>
        public Dictionary<Type, int> messagesParsedByType = new Dictionary<Type, int>();

        /// <summary>
        /// buffer accumulating all the bytes received from the server
        /// </summary>
        private ByteBuffer messageTrail = new ByteBuffer(2048);

        /// <summary>
        /// offset within the buffer
        /// </summary>
        private int offset;

        /// <summary>
        /// last message's header read from buffer
        /// </summary>
        private MessageHeader lastHeader;
       
        public List<BaseResponse> ParseResponse(ByteBuffer pack)
        {
            messageTrail.Append(pack);
            var resps = ParseResponseSeries();
            ShrinkBuffer();
            return resps;
        }

        private List<BaseResponse> ParseResponseSeries()
        {
            var resps = new List<BaseResponse>();
            while (true)
            {
                if (lastHeader != null)
                {
                    if (messageTrail.length - offset < lastHeader.msgSize) break;
                    var resp = ParseRawData(messageTrail);
                    if (resp != null)
                        resps.Add(resp);
                    
                    offset += lastHeader.msgSize;
                    lastHeader = null;
                    continue;
                }
                if (messageTrail.length - offset < MessageHeader.StructSize) break;
                lastHeader = MessageHeader.ReadFromBuffer(messageTrail, offset);
                offset += MessageHeader.StructSize;
            }
            return resps;
        }

        private void ShrinkBuffer()
        {
            if (offset < 2048) return;
            var buf = new ByteBuffer(2048);
            buf.Append(messageTrail, offset);
            offset = 0;
            messageTrail = buf;
        }

        private BaseResponse ParseRawData(ByteBuffer buf)
        {
            MessageType msgType;
            try
            {
                msgType = (MessageType)lastHeader.msgId;
            }
            catch
            {
                return null;
            }

            BaseResponse resp = null;
            if (msgType == MessageType.RejectResponse)
                resp = RejectResponse.ReadFromBuffer(lastHeader, buf, offset);
           
            else if (msgType == MessageType.NewOrderReport)
                resp = OrderResponse.ReadFromBuffer(lastHeader, buf, offset);
                
            else if (msgType == MessageType.CancelReport)
                resp = CancelOrderResponse.ReadFromBuffer(lastHeader, buf, offset);                

            else if (msgType == MessageType.ExecutionReport)
                resp = ExecutionReport.ReadFromBuffer(lastHeader, buf, offset);                

            else if (msgType == MessageType.MassCancelReport)
                resp = MassCancelResponse.ReadFromBuffer(lastHeader, buf, offset);

            if (resp != null)
            {
                if (!messagesParsedByType.TryGetValue(resp.GetType(), out var count))
                    messagesParsedByType.Add(resp.GetType(), 1);
                else messagesParsedByType[resp.GetType()] = count + 1;
            }

            return resp;
        }
    }
}
