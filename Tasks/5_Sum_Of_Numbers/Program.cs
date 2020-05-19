using System;

namespace _5_Sum_Of_Numbers
{
    class Program
    {
        // 1.1.5    Sum Of Numbers
        // Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9.
        // Сумма этих чисел будет равна 23. Напишите программу, которая выводит на экран сумму
        // всех чисел меньше 1000, кратных 3 или 5.

        static void Main(string[] args)
        {
            Console.WriteLine("X-Mas Tree");
            Console.WriteLine(new string('-', 20));

            OutNumbers(1000, 3, 5);

            Console.ReadKey();
        }

        static void OutNumbers(int maxSum, params int[] numbers)
        {
            int sum = 0;
            int number = 0; // Для избегания повторений

            for (int iSum = 1; iSum < maxSum; iSum++)
            {
                for (int iNumbers = 0; iNumbers < numbers.Length; iNumbers++)
                {
                    if ((iSum % numbers[iNumbers]) == 0 && iSum != number)
                    {
                        Console.WriteLine(" " + iSum);
                        
                        sum += number = iSum;
                    }
                }
            }

            Console.WriteLine("Sum = " + sum);
        }
    }
}
