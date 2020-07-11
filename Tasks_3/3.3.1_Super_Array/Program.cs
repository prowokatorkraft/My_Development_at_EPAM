using System;
using _3._3._1_Super_Array.Extensions;

namespace _3._3._1_Super_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1,2,3,4,5,6,10,1,6,6 };

            Console.WriteLine(test.FrequentValue());

            Console.ReadKey();
        }
    }
}
