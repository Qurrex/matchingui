using System;
using System.Collections.Generic;

namespace QurrexMatch.Lib.Model
{
    public partial class MessageParser
    {
        /// <summary>
        /// new package's time is stored here in a stack way
        /// </summary>
        class ResponseTimeStack
        {
            private List<DateTime> requestObtainedTimes = new List<DateTime>();

            public void Push(DateTime time)
            {
                requestObtainedTimes.Add(time);
            }

            public DateTime Pop()
            {
                if (requestObtainedTimes.Count == 0) return DateTime.Now;
                var time = requestObtainedTimes[0];
                requestObtainedTimes.RemoveAt(0);
                return time;
            }
        }
    }
}
