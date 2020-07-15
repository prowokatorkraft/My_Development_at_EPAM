using System;
using System.Linq;

namespace _3._3._1_Super_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] test1 = { 1, 2, 3, 4, 5, 6, 10, 1, 6, 6 };

            Console.WriteLine(test1.Act((d) => d.Sum()));
            test1.Act((d) => Console.WriteLine(d.Sum()));

            Console.WriteLine(test1.TotalSum());
            Console.WriteLine(test1.AverageValue());
            Console.WriteLine(test1.FrequentValue());


            Console.ReadKey();
        }
    }
}
