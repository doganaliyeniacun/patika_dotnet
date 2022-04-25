using System;

namespace proje_1
{
    public static class Extensions
    {
        public static Int32? ParseInt32(this string str)
        {
            Int32 k;
            if (Int32.TryParse(str, out k))
                return k;
            return null;
        }
    }
}