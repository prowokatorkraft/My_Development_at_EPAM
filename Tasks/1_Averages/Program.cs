using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Averages
{
    // 1.2.1    Averages
    // Напишите программу, которая определяет среднюю длину слова во введённой текстовой строке. 
    // Учтите, что символы пунктуации на длину слов влиять не должны. Не стоит искать каждый символ-разделитель вручную: 
    // пожалейте своё время и используйте стандартные методы классов String и Char.
    // Регулярные выражения не использовать.
    // В случае дробного результата (х.5) – можете как оставить его таким, так и округлить.
    // Стоит оставить комментарий в коде, указывающий, какое решение вы приняли.


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Averages");
            Console.WriteLine(new string('-', 25));

            Console.WriteLine("Enter text:");
            
            string str = Console.ReadLine();

            Console.WriteLine(new string('-', 25));

            char[] simbols = { ' ', '.', ',', '!', '?', '"', '\'', ':', ';' };
            List<StringBuilder> list = new List<StringBuilder>();

            // Деление на слова
            int Count = 0;
            foreach (var item in str.Split(simbols, StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrWhiteSpace(item)) continue;

                list.Add(new StringBuilder());
                
                // Устранение знаков припинаний
                foreach (char simbol in item)
                {
                    if(char.IsSeparator(simbol)) break;

                    list[Count].Append(simbol);
                }

                Count++;
            }
            
            Count = 0;
            foreach (var item in list)
            {
                Count += item.Length;
            }
            // Подсчет осуществляется с округлением
            Count = Count / list.Count;
            
            
            Console.WriteLine($"The Average long: {Count}");

            Console.ReadKey();
        }


    }
}
