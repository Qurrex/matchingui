using System;
using System.Collections.Generic;
using System.Threading;
using QurrexMatch.Lib.Model.Response;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// a thread-safe storage for keeping orders placed (confirmed)
    /// used to get orders to cancel
    /// </summary>
    public class OrderResponseSafeList
    {
        /// <summary>
        /// an internal list keeping the orders
        /// </summary>
        private readonly List<OrderResponse> lastOrderResponses = new List<OrderResponse>();

        /// <summary>
        /// a locking manager
        /// </summary>
        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        /// <summary>
        /// used to peek random order
        /// </summary>
        private readonly Random rand = new Random();

        /// <summary>
        /// collection's size limit
        /// </summary>
        private readonly int maxLength = 100, lengthStep = 25;

        public OrderResponseSafeList()
        {
        }

        public OrderResponseSafeList(int maxLength, int lengthStep)
        {
            this.maxLength = maxLength;
            this.lengthStep = lengthStep;
        }

        /// <summary>
        /// store an order
        /// </summary>
        public void PushResponse(OrderResponse resp)
        {
            locker.EnterWriteLock();
            try
            {
                lastOrderResponses.Add(resp);
                if (lastOrderResponses.Count > maxLength)
                    lastOrderResponses.RemoveRange(0, lengthStep);
            }
            finally 
            {
                locker.ExitWriteLock();
            }
        }

        /// <summary>
        /// peek a random order among the orders stored
        /// </summary>
        public OrderResponse PopRandomResponse()
        {
            locker.EnterWriteLock();
            try
            {
                if (lastOrderResponses.Count == 0) return null;
                var index = rand.Next(lastOrderResponses.Count);
                var resp = lastOrderResponses[index];
                lastOrderResponses.RemoveAt(index);
                return resp;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
