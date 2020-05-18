using System;

namespace Task_1
{
    // 1.1.1	RECTANGLE
    // Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
    // Если пользователь вводит некорректные значения (отрицательные или ноль), 
    // должно выдаваться сообщение об ошибке. Возможность ввода пользователем 
    // строки вида «абвгд» или нецелых чисел игнорировать.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rectangle area");
            Console.WriteLine(new string('-', 20));


            Console.Write("Enter side A: ");

            if (Rectangle.SetSide(out Rectangle.a))
            {
                Console.Write("Enter side B: ");

                if (Rectangle.SetSide(out Rectangle.b))
                {
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("Rectangle area = " + Rectangle.GetAria());
                }
                else Console.WriteLine("Incorrect enter!");
            }
            else Console.WriteLine("Incorrect enter!");
                

            Console.ReadKey();
        }



        static class Rectangle
        {
            public static int a, b;

            public static bool SetSide(out int side)
            {
                string value = Console.ReadLine();

                if (int.TryParse(value, out side) && side > 0)
                    return true;
                else
                    return false;
            }

            public static int GetAria()
            {
                return a * b;
            }
        }
    }
}
