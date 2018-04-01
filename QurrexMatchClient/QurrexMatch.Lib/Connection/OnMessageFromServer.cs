using System;

namespace QurrexMatch.Lib.Connection
{
    public delegate void OnMessageFromServer(ByteBuffer msg, DateTime receivedTime);
}
