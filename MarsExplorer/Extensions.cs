using System;
using System.Linq;

namespace MarsExplorer
{
    public static class Extensions
    {
        public static int ToInt32(this string value)
        {
            int result = Convert.ToInt32(value);

            return result;
        }

        public static bool IsInRange(this int value, int max, int min = 0)
        {
            bool result = value >= min && value <= max;
            return result;
        }
        public static bool IsOutOfRange(this int value, int max, int min = 0)
        {
            bool result = !value.IsInRange(max, min);
            return result;
        }

        //https://stackoverflow.com/a/894325/312844
        public static bool IsNumber(this string value)
        {
            bool result = value.All(p => char.IsNumber(p));
            return result;
        }
    }


}
