using System;

namespace WithFormat
{
    public class TryingThingsOut
    {
        public void TryingThisStuff()
        {
            const int testNum = 6;

            Console.WriteLine(testNum.DecimalFormat(6));
        }
    }

    public static class Extentions
    {
        public static string DecimalFormat(this int input)
        {
            return input.ToString(String.Format("D"));
        }

        public static string DecimalFormat(this int input, int digits)
        {
            return input.ToString(String.Format("D{0}", digits));
        }
    }
}