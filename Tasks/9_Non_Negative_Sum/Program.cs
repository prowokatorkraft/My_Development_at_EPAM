using System;

namespace _9_Non_Negative_Sum
{
    // 1.1.9    Non Negative Sum
    // Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
    // Число элементов в массиве и их тип определяются разработчиком.

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -5, 4, -3, 2, -1, 1, -2, 3, -4, 5 };

            Console.WriteLine("No Positive");
            Console.WriteLine(new string('-', 25));

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 25));

            Console.WriteLine($"Sum: { SumPositiveElements(array) }");

            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает сумму положительных элементов массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int SumPositiveElements(int[] array)
        {
            int sum = 0;

            foreach (var item in array)
            {
                if (item > 0)
                    sum += item;
            }

            return sum;
        }
    }
}
