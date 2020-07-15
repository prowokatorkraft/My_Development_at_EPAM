using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._3._1_Super_Array
{
    internal static class NumberExtensions
    {
        private static U Act<T, U>(IEnumerable<T> values, Func<IEnumerable<T>, U> func)
        {
            return func(values);
        }
        public static U Act<U>(this IEnumerable<decimal> values, Func<IEnumerable<decimal>, U> func)
        {
            return Act<decimal, U>(values, func);
        }
        public static U Act<U>(this IEnumerable<double> values, Func<IEnumerable<double>, U> func)
        {
            return Act<double, U>(values, func);
        }
        public static U Act<U>(this IEnumerable<float> values, Func<IEnumerable<float>, U> func)
        {
            return Act<float, U>(values, func);
        }
        public static U Act<U>(this IEnumerable<int> values, Func<IEnumerable<int>, U> func)
        {
            return Act<int, U>(values, func);
        }
        public static U Act<U>(this IEnumerable<long> values, Func<IEnumerable<long>, U> func)
        {
            return Act<long, U>(values, func);
        }

        private static void Act<T>(IEnumerable<T> values, Action<IEnumerable<T>> func)
        {
            func(values);
        }
        public static void Act(this IEnumerable<decimal> values, Action<IEnumerable<decimal>> func)
        {
            Act<decimal>(values, func);
        }
        public static void Act(this IEnumerable<double> values, Action<IEnumerable<double>> func)
        {
            Act<double>(values, func);
        }
        public static void Act(this IEnumerable<float> values, Action<IEnumerable<float>> func)
        {
            Act<float>(values, func);
        }
        public static void Act(this IEnumerable<int> values, Action<IEnumerable<int>> func)
        {
            Act<int>(values, func);
        }
        public static void Act(this IEnumerable<long> values, Action<IEnumerable<long>> func)
        {
            Act<long>(values, func);
        }

        public static decimal TotalSum(this IEnumerable<decimal> values)
        {
            return values.Sum();
        }
        public static double TotalSum(this IEnumerable<double> values)
        {
            return values.Sum();
        }
        public static float TotalSum(this IEnumerable<float> values)
        {
            return values.Sum();
        }
        public static int TotalSum(this IEnumerable<int> values)
        {
            return values.Sum();
        }
        public static long TotalSum(this IEnumerable<long> values)
        {
            return values.Sum();
        }

        public static decimal AverageValue(this IEnumerable<decimal> values)
        {
            return values.Average();
        }
        public static double AverageValue(this IEnumerable<double> values)
        {
            return values.Average();
        }
        public static float AverageValue(this IEnumerable<float> values)
        {
            return values.Average();
        }
        public static int AverageValue(this IEnumerable<int> values)
        {
            return (int) values.Average();
        }
        public static long AverageValue(this IEnumerable<long> values)
        {
            return (long) values.Average();
        }

        private static T FrequentValue<T>(IEnumerable<T> values)
        {
            T value = default(T);
            int count = -1;

            int newCount = -1;

            foreach (T item in values)
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
        public static decimal FrequentValue(this IEnumerable<decimal> values)
        {
            return FrequentValue<decimal>(values);
        }
        public static double FrequentValue(this IEnumerable<double> values)
        {
            return FrequentValue<double>(values);
        }
        public static float FrequentValue(this IEnumerable<float> values)
        {
            return FrequentValue<float>(values);
        }
        public static int FrequentValue(this IEnumerable<int> values)
        {
            return FrequentValue<int>(values);
        }
        public static long FrequentValue(this IEnumerable<long> values)
        {
            return FrequentValue<long>(values);
        }
    }
}
