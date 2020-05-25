using System;
using System.Collections.Generic;

namespace _6_Font_Adjustment
{
    // 1.1.6    Font Adjustment
    // Для форматирования текста надписи можно использовать различные начертания:
    // полужирное, курсивное и подчёркнутое, а также их сочетания.
    // Предложите способ хранения информации о форматировании текста надписи
    // и напишите программу, которая позволяет устанавливать и изменять начертание:

    [Flags]
    enum Font
    {
        None = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Font Adjustment");

            Font font = Font.None;
            int enter;

            while (true)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Параметры надписи: " + font.ToString());

                Console.WriteLine(
                                   "Введите:" +
                                   "\n\t1: bold" +
                                   "\n\t2: italic" +
                                   "\n\t3: underline"
                                  );

                if (int.TryParse(Console.ReadLine(), out enter) && enter < 4)
                {
                    if (enter == 0) return;  // Для выхода из приложения
                    if (enter == 3) enter++;

                    ChangeFonts((Font)enter, ref font);
                }
                else Console.WriteLine("Incorrect enter!");
            }
        }

        /// <summary>
        /// Изменяет состояние начертания
        static void ChangeFonts(Font setFont, ref Font font)
        {
            int fontInt = (int)font; // Во избегание множественных приведений

            switch (setFont)
            {
                // Добавления Font.Bold
                case Font.Bold when fontInt == 0 || fontInt == 2 || fontInt == 4 || fontInt == 6:
                    font = fontInt + Font.Bold;
                    break;

                // Удаление Font.Bold
                case Font.Bold when fontInt == 1 || fontInt == 3 || fontInt == 5 || fontInt == 7:
                    font = fontInt - Font.Bold;
                    break;

                // Добавления Font.Italic
                case Font.Italic when fontInt == 0 || fontInt == 1 || fontInt == 4 || fontInt == 5:
                    font = fontInt + Font.Italic;
                    break;

                // Удаление Font.Italic
                case Font.Italic when fontInt == 2 || fontInt == 3 || fontInt == 6 || fontInt == 7:
                    font = fontInt - Font.Italic;
                    break;

                // Добавления Font.Underline
                case Font.Underline when fontInt == 0 || fontInt == 1 || fontInt == 2 || fontInt == 3:
                    font = fontInt + Font.Underline;
                    break;

                // Удаление Font.Underline
                case Font.Underline when fontInt == 4 || fontInt == 5 || fontInt == 6 || fontInt == 7:
                    font = fontInt - Font.Underline;
                    break;

                default:
                    throw new ArgumentException("Incorrect argument setFont!");
            }
        }
    }
}
