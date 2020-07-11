using System;
using System.Linq;

namespace _3._3._1_Super_Array.Extensions
{
    internal static class ExtensionsIntArray
    {
        public static T Act<T>(this int[] values, Func<int[], T> func)
        {
            return func(values);
        }
        public static void Act(this int[] values, Action<int[]> func)
        {
            func(values);
        }

        public static int TotalSum(this int[] values)
        {
            return values.Sum();
        }

        public static int AverageValue(this int[] values)
        {
            return (int) values.Average();
        }

        public static int FrequentValue(this int[] values)
        {
            int value = 0;
            int count = -1;

            int newCount = -1;

            foreach (var item in values)
            {
                newCount = values.Count(e => e.Equals(item));

                if (newCount > count)
                {
                    value = item;
                    count = newCount;
                }
            }

            return value;
        }
    }
}
