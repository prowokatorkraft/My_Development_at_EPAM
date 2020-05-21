using System;
using System.Linq;

namespace _2_Doubler
{
    // 1.2.2    Doubler
    // Напишите программу, которая удваивает в первой введённой 
    // строке все символы, принадлежащие второй введённой строке.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Doubler");
            Console.WriteLine(new string('-', 25));

            char[] simbols1;
            Console.Write("Enter text 1: ");
            simbols1 = Console.ReadLine().ToCharArray();

            char[] simbols2;
            Console.Write("Enter text 2: ");
            simbols2 = Console.ReadLine().Distinct().ToArray();

            Console.WriteLine(new string('-', 25));

            for (int i1 = 0; i1 < simbols1.Length; i1++)
            {
                for (int i2 = 0; i2 < simbols2.Length; i2++)
                {
                    if (simbols1[i1] == simbols2[i2])
                    {
                        Console.Write(simbols1[i1]);
                    }
                }

                Console.Write(simbols1[i1]);
            }

            Console.ReadKey();
        }
    }
}
