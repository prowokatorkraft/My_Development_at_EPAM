using System;
using System.Collections.Generic;

namespace _6_Font_Adjustment
{
    // 1.1.6    Font Adjustment
    // Для форматирования текста надписи можно использовать различные начертания:
    // полужирное, курсивное и подчёркнутое, а также их сочетания.
    // Предложите способ хранения информации о форматировании текста надписи
    // и напишите программу, которая позволяет устанавливать и изменять начертание:


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Font Adjustment");
            
            Font font = new Font(false, false, false);
            int enter;

            while (true)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Параметры надписи: " + GetFonts(font));

                Console.WriteLine(
                                   "Введите:" +
                                   "\n\t1: bold" +
                                   "\n\t2: italic" +
                                   "\n\t3: bold"
                                  );

                if (int.TryParse(Console.ReadLine(), out enter) && enter < 4)
                {
                    if (enter == 0) return;  // Для выхода из приложения

                    ChangeFonts(enter, ref font);
                }
                else Console.WriteLine("Incorrect enter!");
            }
        }

        /// <summary>
        /// Возвращает строку с активированными начертаниями
        /// </summary>
        static string GetFonts(Font font)
        {
            if (font.bold)
            {
                if (font.italic)
                {
                    if (font.underline)
                        return "bold, italic, underline";
                    else
                        return "bold, italic";
                }
                else if (font.underline)
                    return "bold, underline";
                else
                    return "bold";
            }
            else if (font.italic)
            {
                if (font.underline)
                    return "italic, underline";
                else
                    return "italic";
            }
            else if (font.underline)
                return "underline";
            
            return "none";
        }
        /// <summary>
        /// Изменяет состояние начертания
        static void ChangeFonts(int setFont, ref Font font)
        {
            switch (setFont)
            {
                case 1:
                    font.bold = !font.bold;
                    break;
                case 2:
                    font.italic = !font.italic;
                    break;
                case 3:
                    font.underline = !font.underline;
                    break;
                default:
                    throw new ArgumentException("Incorrect argument setFont! (1-3)");
            }
        }
    }

    struct Font
    {
        public bool bold { get; set; }
        public bool italic { get; set; }
        public bool underline { get; set; }

        public Font(bool bold, bool italic, bool underline)
        {
            this.bold = bold;
            this.italic = italic;
            this.underline = underline;
        }
    }
}
