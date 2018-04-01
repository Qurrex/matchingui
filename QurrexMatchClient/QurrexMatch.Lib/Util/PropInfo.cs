using System;

namespace QurrexMatch.Lib.Util
{
    /// <summary>
    /// a utility class to get property's size in bytes
    /// </summary>
    public static class PropInfo
    {
        public static int GetSize<T, V>(T src, Func<T, V> ex)
        {
            return System.Runtime.InteropServices.Marshal.SizeOf<V>();
        }
    }
}
