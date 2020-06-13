using System;
using _2._1._2_Custom_Paint.Figure.Circle;

namespace _2._1._2_Custom_Paint
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle;

            for (int i = 1; i < 15; i++)
            {
                circle = new Circle(i);
                
                Console.WriteLine(circle);
            }

            Console.ReadKey();
        }
    }
}
