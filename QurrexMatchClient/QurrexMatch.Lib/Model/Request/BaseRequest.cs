using System;
using QurrexMatch.Lib.Connection;

namespace QurrexMatch.Lib.Model.Request
{
    /// <summary>
    /// base message being sent to the matching server
    /// </summary>
    public abstract class BaseRequest : BaseMessage
    {
        /// <summary>
        /// 16 bytes unique string
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// message id, unique (autoincremented) within each session (connection)
        /// </summary>
        public Int64 SessionId { get; set; }

        /// <summary>
        /// serialize message body to byte array
        /// </summary>
        /// <returns></returns>
        public abstract ByteBuffer Serialize();
    }
}
