using System;
using System.Collections.Generic;

namespace _3._1._1_Weakest_Link
{
    class Program
    {
        static void Main(string[] args)
        {
            int _lenght;
            int _coef;
            List<int> _people;

            while (true)
            {
                _lenght = 0;
                _coef = 0;
                _people = new List<int>();

                Console.WriteLine("Введите N:");
                int.TryParse(Console.ReadLine(), out _lenght);

                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");
                int.TryParse(Console.ReadLine(), out _coef);

                if (_lenght < 1 || _coef < 1)
                {
                    continue;
                }

                InitializeList(_people, _lenght);

                Console.WriteLine($"Сгенерирован круг людей: {_lenght}. Начинаем вычеркивать каждого {_coef}");

                CrossElementsOut<int>(_people, _coef);

                Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей");
                Console.ReadKey();

                Console.Clear();
            }
        }

        private static void InitializeList(List<int> people, int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                people.Add(i);
            }
        }

        private static void CrossElementsOut<T>(List<T> array, int coefficient)
        {
            for (int round = 0, index = 0, count = 0; coefficient <= array.Count; index++, count++)
            {
                if (count == coefficient - 1)
                {
                    round++;

                    array.RemoveAt(index);

                    count = -1;

                    Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {array.Count}");
                }

                if (index >= array.Count - 1)
                {
                    index = -1;
                }
            }
        }
    }
}
