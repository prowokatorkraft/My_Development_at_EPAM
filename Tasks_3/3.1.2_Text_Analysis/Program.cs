using System;

namespace _3._1._2_Text_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("Text_Analysis");
                Console.WriteLine(new string('=', 20));

                Console.WriteLine("Enter text:");

                Analyzer analyzer = new Analyzer(Console.ReadLine());

                Console.WriteLine(new string('=', 20));

                Console.Write(analyzer.ToString());

                Console.WriteLine(new string('=', 20));

                Console.WriteLine("To exit, press \"q\"");

                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }

                Console.Clear();
            }
        }
    }
}
