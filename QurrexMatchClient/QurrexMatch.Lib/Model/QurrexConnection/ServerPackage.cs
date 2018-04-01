using System;
using QurrexMatch.Lib.Connection;

namespace QurrexMatch.Lib.Model.QurrexConnection
{
    /// <summary>
    /// data and time stored for the package
    /// received from the Qurrex server by TCP/IP
    /// </summary>
    public class ServerPackage
    {
        public ByteBuffer buffer;

        public DateTime time;

        public ServerPackage()
        {

        }

        public ServerPackage(ByteBuffer buffer)
        {
            this.buffer = buffer;
            time = DateTime.Now;
        }
    }
}
