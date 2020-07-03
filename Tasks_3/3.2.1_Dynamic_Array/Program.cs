using System;
using DynamicArray;

namespace _3._2._1_Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(new int[] { 2,3,4 });



            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}