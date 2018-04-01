using System.Collections.Generic;
using System.Threading;

namespace QurrexMatch.Lib.Util
{
    public class ThreadSafeList<T>
    {
        private List<T> items = new List<T>();

        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        public void Push(T item)
        {
            locker.EnterWriteLock();
            items.Add(item);
            locker.ExitWriteLock();
        }

        public List<T> PopAll()
        {
            locker.EnterWriteLock();
            try
            {
                var copy = items;
                items = new List<T>();
                return copy;
            }
            finally 
            {
                locker.ExitWriteLock();
            }
        }
    }
}
