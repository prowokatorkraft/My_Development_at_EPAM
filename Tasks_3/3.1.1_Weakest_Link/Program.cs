using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3._1._1_Weakest_Link
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.AutoFlush = true;
            Debug.Listeners.Add(new TextWriterTraceListener(System.IO.File.CreateText("Log.txt")));
            Debug.WriteLine("Debug Information-Product Starting ");
            Debug.Indent();

            while (true)
            {
                int _lenght = 0;
                int _coef = 0;
                List<int> _people = new List<int>();


                Console.WriteLine("Введите N:");

                Debug.WriteLineIf(
                    int.TryParse(Console.ReadLine(), out _lenght), 
                    $"Initialized _lenght ({_lenght})", "Info");

                Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд:");

                Debug.WriteLineIf(
                    int.TryParse(Console.ReadLine(), out _coef), 
                    $"Initialized _coef ({_coef})", "Info");


                if (_lenght < 1 || _coef < 1)
                {
                    Debug.WriteIf(_lenght < 1, "invalid value entered _lenght", "Warm");
                    Debug.WriteIf(_coef < 1, "invalid value entered _lenght", "Warm");

                    continue;
                }

                for (int i = 0; i < _lenght; i++)
                {
                    _people.Add(i);
                }
                Debug.WriteLine($"{_lenght} items added to _people", "Info");

                Console.WriteLine($"Сгенерирован круг людей: {_lenght}. Начинаем вычеркивать каждого {_coef}");


                Debug.WriteLine("Enumerated items started", "Info");
                Debug.Indent();
                for (int round = 0, index = 0, count = 0; _coef <= _people.Count; index++, count++)
                {
                    if (count == _coef - 1)
                    {
                        round++;

                        _people.RemoveAt(index);

                        count = -1;

                        Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {_people.Count}");
                        Debug.WriteLine($"Removed item (round: {round}, index: {index}, _people.Count: {_people.Count})");
                    }

                    if (index >= _people.Count - 1)
                    {
                        index = -1;

                        Debug.WriteLine($"The index is dumped (round: {round}, count: {count})");
                    }
                }
                Debug.Unindent();
                Debug.WriteLine("Enumerated items completed", "Info");

                Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей");
                Console.ReadKey();

                Console.Clear();
            }
        }
    }
}
