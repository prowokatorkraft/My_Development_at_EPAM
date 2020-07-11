using System;
using System.Linq;

namespace _3._3._1_Super_Array.Extensions
{
    internal static class ExtensionsDoubleArray
    {
        public static T Act<T>(this double[] values, Func<double[], T> func)
        {
            return func(values);
        }
        public static void Act(this double[] values, Action<double[]> func)
        {
            func(values);
        }

        public static double TotalSum(this double[] values)
        {
            return values.Sum();
        }

        public static double AverageValue(this double[] values)
        {
            return values.Average();
        }

        public static double FrequentValue(this double[] values)
        {
            double value = 0;
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
