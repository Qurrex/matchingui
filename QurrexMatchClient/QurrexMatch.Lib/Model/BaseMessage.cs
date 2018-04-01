using System.Text;

namespace QurrexMatch.Lib.Model
{
    public abstract class BaseMessage
    {
        public static readonly Encoding encoding = Encoding.ASCII;

        private static readonly char[] zeroSyms = {(char) 0};

        public static string TrimZeroSymbols(string s)
        {
            return s.Trim(zeroSyms);
        }
    }
}
