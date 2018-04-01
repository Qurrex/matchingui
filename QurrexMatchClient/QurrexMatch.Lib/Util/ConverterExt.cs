using System.Globalization;

namespace QurrexMatch.Lib.Util
{
    /// <summary>
    /// default converting from / to string
    /// </summary>
    public static class ConverterExt
    {
        private static CultureInfo culture = CultureInfo.InvariantCulture;

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        public static decimal ToDecimal(this string s)
        {
            return decimal.Parse(s.Trim().Replace(',', '.'), culture);
        }

        public static string ToStringDefault(this int n)
        {
            return n.ToString();
        }

        public static string ToStringDefault(this decimal n)
        {
            return n.ToString(culture);
        }
    }
}
