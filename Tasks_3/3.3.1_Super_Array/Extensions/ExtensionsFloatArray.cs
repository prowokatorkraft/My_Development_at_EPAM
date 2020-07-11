using System;
using System.Linq;

namespace _3._3._1_Super_Array.Extensions
{
    internal static class ExtensionsFloatArray
    {
        public static T Act<T>(this float[] values, Func<float[], T> func)
        {
            return func(values);
        }
        public static void Act(this float[] values, Action<float[]> func)
        {
            func(values);
        }

        public static float TotalSum(this float[] values)
        {
            return values.Sum();
        }

        public static float AverageValue(this float[] values)
        {
            return values.Average();
        }

        public static float FrequentValue(this float[] values)
        {
            float value = 0;
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
