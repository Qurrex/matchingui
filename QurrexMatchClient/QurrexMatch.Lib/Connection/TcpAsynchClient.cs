using System;
using System.Net.Sockets;

namespace QurrexMatch.Lib.Connection
{
    /// <summary>
    /// async wrapper on TCP/IP client
    /// that wraps BeginXXX ... EndXXX in events
    /// </summary>
    public class TcpAsyncClient
    {
        /// <summary>
        /// just for counting connections opened / closed
        /// </summary>
        public static volatile int connectionsOpened;

        /// <summary>
        /// used in BeginXXX ... EndXXX
        /// </summary>
        class StateObject
        {
            // Client socket
            public Socket workSocket;
            // Size of receive buffer  
            public const int BufferSize = 1024;
            // Receive buffer
            public byte[] buffer = new byte[BufferSize];
            // Received data string 
            public ByteBuffer byteBuffer = new ByteBuffer(1024);
        }

        /// <summary>
        /// on message (data) got from server
        /// </summary>
        public OnMessageFromServer onMessage;

        /// <summary>
        /// called when got exception / disconnected
        /// </summary>
        public Action<string> onConnectionError;

        /// <summary>
        /// called when e.g. connected to server
        /// </summary>
        public Action<string> onStatusMessage;

        private volatile bool isStopping;

        /// <summary>
        /// internal socket client
        /// </summary>
        private Socket client;

        public void Connect(string uri)
        {
            isStopping = false;
            var hostPort = uri.Split(':');
            var host = hostPort[0];
            var port = int.Parse(hostPort[1]);
            client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.BeginConnect(host, port, EndConnect, null);
            }
            catch (Exception e)
            {
                onConnectionError.Invoke($"Error in begin connect: {e.Message}");
            }
        }

        public void Disconnect()
        {
            isStopping = true;
            connectionsOpened--;
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            onStatusMessage("client has disconnected");
        }

        public void SendMessage(byte[] data)
        {
            SendMessage(data, data.Length);
        }

        public void SendMessage(byte[] data, int length)
        {
            if (data.Length == 0) return;
            try
            {
                client.BeginSend(data, 0, length, SocketFlags.None, out var erCode, EndSend, null);
            }
            catch (Exception e)
            {
                onConnectionError.Invoke($"Error in begin send: {e.Message}");
            }
        }

        private void EndSend(IAsyncResult ar)
        {
            try
            {
                client.EndSend(ar);
            }
            catch (Exception e)
            {
                onConnectionError.Invoke($"Error in end send: {e.Message}");
            }
        }

        private void EndConnect(IAsyncResult ar)
        {
            try
            {
                client.EndConnect(ar);
                connectionsOpened++;

                var state = new StateObject { workSocket = client };

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    EndReceive, state);

                onStatusMessage("client is connected");
            }
            catch (Exception e)
            {
                onConnectionError.Invoke($"Error in end connect: {e.Message}");
            }
        }

        private void EndReceive(IAsyncResult ar)
        {
            var now = DateTime.Now;
            var state = (StateObject)ar.AsyncState;
            int bytesRead;
            try
            {
                bytesRead = client.EndReceive(ar);
            }
            catch (Exception e)
            {
                onConnectionError.Invoke($"Error in end receive: {e.Message}");
                return;
            }

            if (bytesRead > 0)            
                state.byteBuffer.Append(state.buffer, bytesRead);

            if (state.byteBuffer.length != 0)
            {
                var buf = state.byteBuffer;
                state.byteBuffer = new ByteBuffer(1024);                
                onMessage(buf, now);
            }

            if (state.byteBuffer.length != 0)
            {
                if (!isStopping)
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        EndReceive, state);
                return;
            }

            try
            {
                if (!isStopping)
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        EndReceive, state);
            }
            catch (Exception e)
            {
                onConnectionError.Invoke($"Server has closed the connection: {e.Message}");
            }
        }
    }
}
