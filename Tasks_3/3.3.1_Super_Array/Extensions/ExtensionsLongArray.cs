using System;
using System.Linq;

namespace _3._3._1_Super_Array.Extensions
{
    internal static class ExtensionsLongArray
    {
        public static T Act<T>(this long[] values, Func<long[], T> func)
        {
            return func(values);
        }
        public static void Act(this long[] values, Action<long[]> func)
        {
            func(values);
        }

        public static long TotalSum(this long[] values)
        {
            return values.Sum();
        }

        public static long AverageValue(this long[] values)
        {
            return (long)values.Average();
        }

        public static long FrequentValue(this long[] values)
        {
            long value = 0;
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
