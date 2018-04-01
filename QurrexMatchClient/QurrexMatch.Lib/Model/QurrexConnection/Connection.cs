using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using QurrexMatch.Lib.Connection;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.Request;
using QurrexMatch.Lib.Model.Response;

namespace QurrexMatch.Lib.Model.QurrexConnection
{
    /// <summary>
    /// class used to set up connection with the matching server,
    /// to send request to the server
    /// to fire the event when the server responds
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// matching server URI, provided in Ctor()
        /// </summary>
        public string uri;

        /// <summary>
        /// server is connected / disconnected (flag)
        /// </summary>
        public bool Connected { get; private set; }

        /// <summary>
        /// self-reconnecting TCP/IP connection to the mathcing server
        /// </summary>
        private SafeTcpClient conn;

        /// <summary>
        /// action provided in Ctor()
        /// called by this class when it logs smth
        /// </summary>
        private readonly Logger logMessage;

        /// <summary>
        /// next request Id, starts from 0
        /// unique per connection (session)
        /// </summary>
        private Int64 nextSessionId = 0;

        /// <summary>
        /// an object that parses messages received from the server
        /// </summary>
        private readonly MessageParser parser = new MessageParser();

        /// <summary>
        /// an callback being invoked on parsing server's message
        /// parameters: response, processing interval, connection id
        /// </summary>
        public Action<BaseResponse, UInt32, int> onResponse;

        /// <summary>
        /// stores requests' time to calculate the round trip time
        /// </summary>
        private readonly ConcurrentDictionary<string, DateTime> requestTimeById = new ConcurrentDictionary<string, DateTime>();

        /// <summary>
        /// a thread-safe wrapper for requestTimeById.Count
        /// </summary>
        public int requestsWaitingForResponses;

        public Dictionary<Type, int> MessagesByType => parser.messagesParsedByType;

        /// <summary>
        /// an arbitrary number to distinquish this connection among others
        /// </summary>
        public readonly int connectionId;

        /// <summary>
        /// used to give a request an unique Id
        /// </summary>
        private readonly Random rand = new Random();

        public Connection(string uri, Logger logMessage, int connectionId)
        {
            this.uri = uri;
            this.logMessage = logMessage;
            this.connectionId = connectionId;
        }
        
        /// <summary>
        /// just set up TCP-IP connection
        /// no hand-shake, no heartbeat are required
        /// </summary>
        public void Open()
        {
            conn = new SafeTcpClient
            {
                onLogMessage = logMessage,
                onServerMessage = OnServerMessage                
            };

            try
            {
                logMessage.LogMessage($"Connecting to {uri}", LoggingLevel.Verbose);
                conn.Connect(uri);
                Connected = true;
            }
            catch (Exception e)
            {
                logMessage.LogMessage("Error opening TCP/IP connection", LoggingLevel.Critical, LogMessageCode.ConnectionLost);
                Connected = false;
                logMessage?.LogMessage($"Error connecting {uri} - {e.Message}", LoggingLevel.Error);
            }
        }

        /// <summary>
        /// close TCP/IP connection, stop the parsing thread
        /// </summary>
        public void Close()
        {            
            conn.Disconnect();
            Connected = false;
        }

        /// <summary>
        /// reconnect to the server
        /// </summary>
        public void Reconnect()
        {
            logMessage.LogMessage("Reconnecting", LoggingLevel.Critical, LogMessageCode.ConnectionReconnect);
            Close();
            Thread.Sleep(1000);
            Open();
        }

        /// <summary>
        /// send a request to server: new order, cancel order
        /// </summary>
        public void SendRequest(BaseRequest req)
        {
            if (!Connected)
            {
                logMessage.LogMessage("Not connected", LoggingLevel.Verbose);
                return;
            }
            req.RequestId = MakeReuqestId();

            lock (this)
            {
                req.SessionId = Interlocked.Increment(ref nextSessionId);

                var bytes = req.Serialize();
                requestTimeById.TryAdd(req.RequestId, DateTime.Now);
                Interlocked.Increment(ref requestsWaitingForResponses);
                //var str = string.Join(",", bytes.data.Take(bytes.length).Select(d => $"{d:X2}"));
                conn.SendBytes(bytes.data, bytes.length);
            }
        }

        /// <summary>
        /// server send some message
        /// try to deserilize it and call the appropriate event
        /// </summary>
        private void OnServerMessage(ByteBuffer byteBuffer, DateTime receivedTime)
        {
            logMessage.LogMessage("Got a message from server", LoggingLevel.Critical, LogMessageCode.ConnectionSetUp);
            var resps = parser.ParseResponse(byteBuffer);
            if (resps.Count == 0) return;
            resps.ForEach(r => r.responseReceivedTime = receivedTime);

            foreach (var resp in resps)
            {
                var processingTime = 0U;
                if (resp is IOrigRequest request)
                {
                    var reqId = request.GetOrigRequestId();
                    if (!string.IsNullOrEmpty(reqId))
                        if (requestTimeById.TryGetValue(reqId, out var requestTime))
                        {
                            processingTime = (UInt32) (receivedTime.Ticks - requestTime.Ticks);
                            requestTimeById.TryRemove(reqId, out var time);
                            Interlocked.Decrement(ref requestsWaitingForResponses);
                        }
                }
                onResponse(resp, processingTime, connectionId);
            }
        }

        private string MakeReuqestId()
        {
            return DateTime.Now.ToString("HHmmssfff") + rand.Next(100000);
        }
    }
}
