using System;
using System.Collections.Generic;

namespace _3._1._1_Weakest_Link
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int _lenght = 0;
                int _coef = 0;
                List<int> _people = new List<int>();


                Console.WriteLine("Введите N:");

                int.TryParse(Console.ReadLine(), out _lenght);

                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");

                int.TryParse(Console.ReadLine(), out _coef);


                if (_lenght < 1 || _coef < 1)
                {
                    continue;
                }

                for (int i = 0; i < _lenght; i++)
                {
                    _people.Add(i);
                }

                Console.WriteLine($"Сгенерирован круг людей: {_lenght}. Начинаем вычеркивать каждого {_coef}");


                for (int round = 0, index = 0, count = 0; _coef <= _people.Count; index++, count++)
                {
                    if (count == _coef - 1)
                    {
                        round++;

                        _people.RemoveAt(index);

                        count = -1;

                        Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {_people.Count}");
                    }

                    if (index >= _people.Count - 1)
                    {
                        index = -1;
                    }
                }

                Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей");
                Console.ReadKey();

                Console.Clear();
            }
        }
    }
}
