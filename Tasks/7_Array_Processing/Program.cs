using System;

namespace _7_Array_Processing
{
    // 1.1.7    Array Processing
    // Написать программу, которая генерирует случайным образом элементы массива 
    // (число элементов в массиве и их тип определяются разработчиком), определяет для него максимальное 
    // и минимальное значения, сортирует массив и выводит полученный результат на экран.
    // Примечание: LINQ запросы и готовые функции языка(Sort, Max и т.д.) использовать в данном задании запрещается.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Processing");
            Console.WriteLine(new string('-', 20));

            Random rand = new Random();

            int[] array = new int[] 
            {
                rand.Next(100),
                rand.Next(100),
                rand.Next(100),
                rand.Next(100),
                rand.Next(100)
            };

            Console.WriteLine("Array:");

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"Min value: {GetMin(array)}\nMax value: {GetMax(array)}");

            Console.WriteLine(new string('-', 20));

            array = SelectionSortArray(array);

            Console.WriteLine("Sorted array:");

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        static int GetMax(int[] array)
        {
            int maxValue = 0;

            foreach (var item in array)
            {
                if (maxValue < item) maxValue = item;
            }

            return maxValue;
        }
        static int GetMin(int[] array)
        {
            int minValue = 2147483647;

            foreach (var item in array)
            {
                if (minValue > item) minValue = item;
            }

            return minValue;
        }

        static int[] SelectionSortArray(int[] array)
        {
            int min, temp;

            for (int i1 = 0; i1 < array.Length - 1; i1++)                       // Итерация текущего элемента
            {
                min = i1;

                for (int i2 = i1 + 1; i2 < array.Length; i2++)                  // Итерация выбора минимального значения в последующих элементах после текущего
                {
                    if (array[i2] < array[min])
                    {
                        min = i2;
                    }
                }
                temp = array[i1];                                               // Обмен значений текущего элемента с выбранным
                array[i1] = array[min];
                array[min] = temp;
            }

            return array;
        }
    }
}
