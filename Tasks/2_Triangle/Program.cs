using System;

namespace _2_Triangle
{
    // 1.1.2    Triangle
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

                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(new string('*', i + 1));
                }

                Console.WriteLine(new string('-', 20));
            }
            else Console.WriteLine("Incorrect enter!");

            Console.ReadKey();
        }
    }
}
