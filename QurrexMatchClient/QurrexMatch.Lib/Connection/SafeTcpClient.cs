using System;
using System.Threading;
using System.Threading.Tasks;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;

namespace QurrexMatch.Lib.Connection
{
    /// <summary>
    /// TCP/IP client, that catch connection exceptions
    /// and reconnects automatically
    /// </summary>
    public class SafeTcpClient
    {
        /// <summary>
        /// on message(data) got from server
        /// </summary>
        public OnMessageFromServer onServerMessage;

        /// <summary>
        /// on event - connected, disconnected, error
        /// </summary>
        public Logger onLogMessage;

        /// <summary>
        /// internal client that actually connects to server
        /// </summary>
        private TcpAsyncClient client;

        /// <summary>
        /// is internal client connected
        /// </summary>
        private volatile bool isAlive;

        /// <summary>
        /// server's URI
        /// </summary>
        private string uri;

        public void Connect(string uri)
        {
            this.uri = uri;
            isAlive = true;
            TryConnect();
        }

        public void Disconnect()
        {
            isAlive = false;
            CloseConnection();
        }

        public void SendBytes(byte[] msg)
        {
            SendBytes(msg, msg.Length);
        }

        public void SendBytes(byte[] msg, int length)
        {
            try
            {
                if (client != null)
                    client.SendMessage(msg, length);
            }
            catch (Exception e)
            {
                onLogMessage?.LogMessage(e.ToString(), LoggingLevel.Error);
                Reconnect();
            }
        }

        private void CloseConnection()
        {
            if (client == null) return;
            try
            {
                client.Disconnect();
            }
            catch (Exception e)
            {
                onLogMessage?.LogMessage(e.Message, LoggingLevel.Error);
            }
        }

        private void Reconnect()
        {
            if (!isAlive) return;
            Thread.Sleep(200);
            onLogMessage?.LogMessage("reconnecting", LoggingLevel.Critical, LogMessageCode.ConnectionReconnect);
            isAlive = false;
            CloseConnection();
            isAlive = true;
            TryConnect();
        }

        private void TryConnect()
        {
            try
            {
                if (!isAlive) return;
                client = new TcpAsyncClient
                {
                    onMessage = onServerMessage,
                    onStatusMessage = msg => onLogMessage?.LogMessage(msg, LoggingLevel.Verbose)
                };
                client.onConnectionError += msg =>
                {
                    onLogMessage?.LogMessage(msg, LoggingLevel.Critical, LogMessageCode.ConnectionLost);
                    client = null;
                    Reconnect();
                };
                client.Connect(uri);
            }
            catch (Exception e)
            {
                onLogMessage?.LogMessage(e.Message, LoggingLevel.Error, LogMessageCode.ConnectionLost);
                client = null;
                new Task(() =>
                {
                    Thread.Sleep(2000);
                    TryConnect();
                }).Start();
            }
        }
    }
}
