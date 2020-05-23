using System;

namespace _3_Lowercase
{
    // 1.2.3    Lowercase
    // Напишите программу, которая считает количество слов, начинающихся с маленькой буквы. 
    // Предлоги, союзы и междометия считаются словами. Финальную точку в предложении 
    // (как и любой другой знак) можно не учитывать.

    // Вариант без * - разделителем между словами считать ТОЛЬКО пробелы
    // Вариант со * - разделители между словами могут быть любые: запятые, двоеточия, точки с запятой.

    class Program
    {
        static void Main(string[] args)
        {
            string str = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";

            char[] simbols = { ' ', '.', ',', '!', '?', '"', '\'', ':', ';' };

            string[] strs = str.Split(simbols, StringSplitOptions.RemoveEmptyEntries);


            int Count = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                foreach (var item in strs[i])
                {
                    if(char.IsLower(item))
                    {
                        Count++;
                    }

                    break;
                }
            }

            Console.WriteLine("Lowercase");
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Text: ");
            Console.WriteLine(str);

            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Sum: " + Count);

            Console.ReadKey();
        }
    }
}
