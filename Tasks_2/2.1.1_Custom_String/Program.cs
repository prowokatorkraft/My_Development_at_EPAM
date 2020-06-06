using System;
using MyLibrary;

namespace _2._1._1_Custom_String
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString1 = new MyString("bu");
            MyString myString2 = new MyString("b");

            Console.WriteLine($"MyString.Compare(): \t{MyString.Compare(myString1, myString2)}");
            Console.WriteLine($"myString1.CompareTo(): \t{myString1.CompareTo(myString2)}");

            MyString myString3 = myString1 + myString2;
            Console.WriteLine($"myString3.Remove(): \t{myString3.ToString()}");

            myString3.Remove('u');
            Console.WriteLine($"myString3.Remove(): \t{myString3.ToString()}");

            myString3[0] = 't';
            Console.WriteLine($"myString3[0]: \t\t{myString3.ToString()}");

            Console.ReadKey();
        }
    }
}
