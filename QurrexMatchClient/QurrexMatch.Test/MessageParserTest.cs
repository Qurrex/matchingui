using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.QurrexConnection;
using QurrexMatch.Lib.Model.Response;
using QurrexMatch.Lib.Model.Response.ExecReport;

namespace QurrexMatch.Test
{
    [TestFixture]
    public class MessageParserTest
    {
        [Test]
        public void TestParseExecReport()
        {
            var bytes = new byte[]
            {
                // header
                5, 0, 145, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                // body
                49, 53, 49, 50, 53, 57, 56, 50, 49, 54, 56, 48, 51, 56, 0, 0, 81, 117, 114, 114, 101, 120, 95, 49, 0, 0,
                0, 0, 0, 0, 0, 0, 84, 114, 97, 100, 101, 114, 95, 52, 48, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 2, 1,
                10, 0, 0, 0, 0, 0, 0, 0, 64, 58, 99, 194, 89, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 97, 114, 107, 101,
                116, 32, 114, 101, 113, 0, 0, 0, 0, 0, 0, 53, 105, 159, 216, 247, 227, 14, 21, 167, 1, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 1, 57, 0, 0, 0, 0, 0, 0, 0, 64, 58, 99, 194, 89, 1, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0
            };
            var buf = new ByteBuffer(bytes.Length)
            {
                data = bytes,
                length = bytes.Length
            };
            var parser = new MessageParser();
            var messages = parser.ParseResponse(buf);
            Assert.AreEqual(1, messages.Count);
            var report = (ExecutionReport) messages[0];
            Assert.AreEqual(1, report.ExecReport.DealsCount);
        }

        [Test]
        public void TestOneMessage()
        {
            var msg = new RejectResponse
            {
                Time = 123231001,
                RequestId = "201801231418190",
                ErrorCodeInternal = 2
            };
            var buf = new ByteBuffer(128);
            MakeRequestResponse(msg, 707, buf);

            var parser = new MessageParser();
            var resps = parser.ParseResponse(buf);
            Assert.AreEqual(1, resps.Count);
            Assert.AreEqual(msg.Time, ((RejectResponse)resps[0]).Time);
            Assert.AreEqual(msg.RequestId, ((RejectResponse)resps[0]).RequestId);
            Assert.AreEqual(msg.ErrorCodeInternal, ((RejectResponse)resps[0]).ErrorCodeInternal);
        }

        [Test]
        public void TestTwoMessages()
        {
            var buf = new ByteBuffer(128);
            var src = new List<RejectResponse>();
            for (var i = 0; i < 2; i++)
            {
                var msg = new RejectResponse
                {
                    Time = 123231001 + (uint)i,
                    RequestId = "201801231418190",
                    ErrorCodeInternal = (short)(2 + i)
                };
                src.Add(msg);
                MakeRequestResponse(msg, i + 11, buf);
            }
            
            var parser = new MessageParser();
            var resps = parser.ParseResponse(buf);
            Assert.AreEqual(src.Count, resps.Count);
            for (var i = 0; i < src.Count; i++)
            {
                Assert.AreEqual(src[i].Time, ((RejectResponse)resps[i]).Time);
                Assert.AreEqual(src[i].RequestId, ((RejectResponse)resps[i]).RequestId);
                Assert.AreEqual(src[i].ErrorCodeInternal, ((RejectResponse)resps[i]).ErrorCodeInternal);
            }            
        }

        [Test]
        public void TestBufferOverflow()
        {
            var buf = new ByteBuffer(4096);
            var src = new List<RejectResponse>();
            for (var i = 0; i < 90; i++)
            {
                var msg = new RejectResponse
                {
                    Time = 123231001 + (uint)i,
                    RequestId = "201801231418190",
                    ErrorCodeInternal = (short)(2 + i)
                };
                src.Add(msg);
                MakeRequestResponse(msg, i + 11, buf);
            }

            var parser = new MessageParser();
            var resps = parser.ParseResponse(buf);
            Assert.AreEqual(src.Count, resps.Count);
            for (var i = 0; i < src.Count; i++)
            {
                Assert.AreEqual(src[i].Time, ((RejectResponse)resps[i]).Time);
                Assert.AreEqual(src[i].RequestId, ((RejectResponse)resps[i]).RequestId);
                Assert.AreEqual(src[i].ErrorCodeInternal, ((RejectResponse)resps[i]).ErrorCodeInternal);
            }
        }

        private void MakeRequestResponse(RejectResponse msg, int seqid, ByteBuffer buf)
        {
            var header = new MessageHeader
            {
                msgId = (int)MessageType.RejectResponse,
                msgSize = (ushort)RejectResponse.StructSize,
                msgSeq = seqid
            };

            header.AppendToBuffer(buf);
            buf.AppendUint64(msg.Time);
            buf.AppendFixedString(msg.RequestId, Encoding.ASCII, 16);
            buf.AppendInt16(msg.ErrorCodeInternal);
        }
    }
}
