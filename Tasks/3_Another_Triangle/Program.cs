using System;

namespace _3_Another_Triangle
{
    // 1.1.3    Another Triangle
    // Написать программу, которая запрашивает с клавиатуры число N
    // и выводит на экран следующее «изображение», состоящее из N строк:

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Triangle");
            Console.WriteLine(new string('-', 20));

            Console.Write("Enter number: ");

            int length;

            if (int.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine(new string('-', 20));

                int size = 1;

                // Узнаем максимальное колличество символов
                for (int i = 1; i < length; i++)
                    size += 2;

                for (int spaces = size/2, simbol = 1 ; spaces >= 0 ; spaces--, simbol += 2)
                {
                    Console.WriteLine(new string(' ', spaces) + new string('*', simbol));
                }

                Console.WriteLine(new string('-', 20));
            }
            else Console.WriteLine("Incorrect enter!");

            Console.ReadKey();
        }
    }
}
