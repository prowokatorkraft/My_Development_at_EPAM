using System;
using System.Linq;

namespace _3._3._1_Super_Array.Extensions
{
    internal static class ExtensionsDecimalArray
    {
        public static T Act<T>(this decimal[] values, Func<decimal[], T> func)
        {
            return func(values);
        }
        public static void Act(this decimal[] values, Action<decimal[]> func)
        {
            func(values);
        }

        public static decimal TotalSum(this decimal[] values)
        {
            return values.Sum();
        }

        public static decimal AverageValue(this decimal[] values)
        {
            return values.Average();
        }

        public static decimal FrequentValue(this decimal[] values)
        {
            decimal value = 0;
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
