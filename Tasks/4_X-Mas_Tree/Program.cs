using System;

namespace _4_X_Mas_Tree
{
    // 1.1.4    X-Mas Tree
    // Написать программу, которая запрашивает с клавиатуры число N
    // и выводит на экран следующее «изображение», состоящее из N треугольников:

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("X-Mas Tree");
            Console.WriteLine(new string('-', 20));

            Console.Write("Enter number: ");

            int length;

            if (int.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine(new string('-', 20));

                DrawTree(length);

                Console.WriteLine(new string('-', 20));
            }
            else Console.WriteLine("Incorrect enter!");

            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает максимальное колличетсво символов в строке
        /// </summary>
        static int GetMaxSimbol(int length, int size)
        {
            for (int i = 1; i < length; i++)
                size += 2;

            return size;
        }
        /// <summary>
        /// Рисует треугольники в консоли
        /// </summary>
        static void DrawTree(int length)
        {
            int allSize = GetMaxSimbol(length, 1);

            for (int iterator = 0; iterator < length; iterator++)
            {
                int size = GetMaxSimbol(iterator + 1, 1);
                int halfSize = (allSize / 2) - (size / 2);

                for (int spaces = allSize / 2, simbol = 1; spaces >= halfSize; spaces--, simbol += 2)
                {
                    Console.WriteLine(new string(' ', spaces) + new string('*', simbol));
                }
            }
        }
    }
}
