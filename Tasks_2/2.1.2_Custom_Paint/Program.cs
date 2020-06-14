using System;
using _2._1._2_Custom_Paint.Figure.Circle;

namespace _2._1._2_Custom_Paint
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring;

            ring = new Ring(new Circle(8), new Circle(4));

            Console.WriteLine(ring);


            Console.ReadKey();
        }
    }
}
