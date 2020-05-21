using System;


namespace _8_No_Positive
{
    // 1.1.8    No Positive
    // Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули.
    // Число элементов в массиве и их тип определяются разработчиком.

    class Program
    {
        static void Main(string[] args)
        {
            int[][][] array;

            GetArray(out array, 2, 2, 10, new int[] { -5, 4, -3, 2, -1, 1, -2, 3, -4, 5 });

            Console.WriteLine("No Positive");
            Console.WriteLine(new string('-', 25));

            OutArray(array);

            Console.WriteLine(new string('-', 25));

            SetElementsIn0(ref array);

            OutArray(array);

            Console.ReadKey();
        }

        /// <summary>
        /// Инициализирует массив
        /// </summary>
        static void GetArray(out int[][][] array, int LenghtArray1, int LenghtArray2, int LenghtArray3, params int[] elements)
        {
            if (LenghtArray3 != elements.Length)
                throw new ArgumentException($"Argument lenght must be ({LenghtArray3})!");

            array = new int[LenghtArray1][][];

            for (int i1 = 0; i1 < LenghtArray1; i1++)
            {
                array[i1] = new int[LenghtArray2][];

                for (int i2 = 0; i2 < LenghtArray2; i2++)
                {
                    array[i1][i2] = new int[LenghtArray3];

                    for (int i3 = 0; i3 < LenghtArray3; i3++)
                    {
                        array[i1][i2][i3] = elements[i3];
                    }
                }
            }
        }

        /// <summary>
        /// Выводит элементы массива в консоль
        /// </summary>
        static void OutArray(int[][][] array)
        {
            for (int i1 = 0; i1 < array.Length; i1++)
            {
                for (int i2 = 0; i2 < array[i1].Length; i2++)
                {
                    for (int i3 = 0; i3 < array[i1][i2].Length; i3++)
                    {
                        Console.Write(array[i1][i2][i3] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Устанавливает значение 0 положительным элементам массива
        /// </summary>
        static void SetElementsIn0(ref int[][][] array)
        {
            for (int i1 = 0; i1 < array.Length; i1++)
            {
                for (int i2 = 0; i2 < array[i1].Length; i2++)
                {
                    for (int i3 = 0; i3 < array[i1][i2].Length; i3++)
                    {
                        if (array[i1][i2][i3] > 0)
                            array[i1][i2][i3] = 0;
                    }
                }
            }
        }
    }
}
