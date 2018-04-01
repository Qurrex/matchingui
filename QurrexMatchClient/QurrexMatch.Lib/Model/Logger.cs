using System;
using System.Collections.Concurrent;
using QurrexMatch.Lib.Model.Enumerations;

namespace QurrexMatch.Lib.Model
{
    /// <summary>
    /// used in several classes (Trader, Connection etc) to log (and filter) messages
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// an action called to log a message
        /// </summary>
        private readonly Action<string> logMessage;

        /// <summary>
        /// logging verbosity level
        /// </summary>
        private readonly LoggingLevel acceptedLevel;

        /// <summary>
        /// used to log some messages just once
        /// </summary>
        private readonly ConcurrentDictionary<LogMessageCode, int> messagesLoggedCount = new ConcurrentDictionary<LogMessageCode, int>();

        public Logger(Action<string> logMessage, LoggingLevel level)
        {
            this.logMessage = logMessage;
            acceptedLevel = level;
        }

        public void LogMessage(string s, LoggingLevel level)
        {
            if (level > acceptedLevel) return;
            logMessage(s);
        }

        /// <summary>
        /// log the message just once
        /// </summary>
        public void LogMessage(string s, LoggingLevel level, LogMessageCode msgCode)
        {
            if (level > acceptedLevel) return;
            if (!messagesLoggedCount.TryAdd(msgCode, 1)) return;
            logMessage(s);
        }
    }

    /// <summary>
    /// used in the Logger class to log some messages just once
    /// </summary>
    public enum LogMessageCode
    {
        /// <summary>
        /// these messages are logged as many times as they passed to Logger
        /// </summary>
        Unsorted = 0,
        ConnectionSetUp,
        ConnectionLost,
        ConnectionReconnect
    }
}
