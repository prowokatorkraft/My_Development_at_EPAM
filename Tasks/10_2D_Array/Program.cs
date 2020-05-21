using System;

namespace _10_2D_Array
{
    class Program
    {
        // 1.1.10   2D Array
        // Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его позиций по обеим 
        // размерностям является чётным числом (например, [1,1] — чётная позиция, а [1,2] — нет). 
        // Определить сумму элементов массива, стоящих на чётных позициях.

        static void Main(string[] args)
        {
            Console.WriteLine("2D Array");
            Console.WriteLine(new string('-', 20));

            int[,] array = new int[10, 10];
            int sum = 0;

            Console.WriteLine($"x: {array.GetLength(0)}, y: {array.GetLength(1)}");

            Console.WriteLine(new string('-', 20));

            for (int i1 = 0; i1 < array.GetLength(0); i1++)
            {
                for (int i2 = 0; i2 < array.GetLength(1); i2++)
                {
                    if (((i1 + i2) % 2) == 0)
                        sum += i1 + i2;
                }
            }

            Console.WriteLine($"Sum: { sum }");

            Console.ReadKey();
        }
    }
}
