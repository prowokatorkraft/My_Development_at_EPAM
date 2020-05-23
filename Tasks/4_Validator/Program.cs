using System;
using System.Text;

namespace _4_Validator
{
    // 1.2.4    Validator
    // Напишите программу, которая заменяет первую букву первого слова в предложении на заглавную. 
    // В качестве окончания предложения можете считать только «.|?|!». Многоточие и «?!» можете опустить.

    class Program
    {
        static void Main(string[] args)
        {
            string str = "я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!";


            StringBuilder newStr = new StringBuilder();

            bool firstSimbol = true;
            foreach (var item in str)
            {
                if (firstSimbol == true)
                {
                    switch (item)
                    {
                        case ' ':
                        case '.':
                        case '!':
                        case '?':
                            newStr.Append(item);
                            break;

                        default:
                            newStr.Append(char.ToUpper(item));
                            firstSimbol = false;
                            break;
                    }
                }
                else
                {
                    switch (item)
                    {
                        case '.':
                        case '!':
                        case '?':
                            newStr.Append(item);
                            firstSimbol = true;
                            break;

                        default:
                            newStr.Append(item);
                            break;
                    }
                }
            }

            // Вывод
            Console.WriteLine("Validator");
            Console.WriteLine(new string('-', 105));

            Console.WriteLine("Text: ");
            Console.WriteLine(str);

            Console.WriteLine(new string('-', 105));

            Console.WriteLine("New text: ");
            Console.WriteLine(newStr);

            Console.ReadKey();
        }
    }
}
