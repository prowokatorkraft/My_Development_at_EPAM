using System;
using System.Threading;
using Game.Logic;

namespace Game.Visualization
{
    class Visualisation : IVisual
    {
        private Thread secondThread;

        private static ConsoleKey consoleSimbol;
        public ConsoleKey ConsoleSimbol
        {
            get { return consoleSimbol; }
        }

        private int healfPlayer;
        private int energyPlayer;

        public void ShowMatrix(Space[,] spaces)
        {
            Console.Clear();
            Console.WriteLine($"Healf: {healfPlayer}, Energy: {energyPlayer}");

            Console.WriteLine(new string('-', spaces.GetLength(0) * 2));

            for (int iY = 0; iY < spaces.GetLength(1); iY++)
            {
                for (int iX = 0; iX < spaces.GetLength(0); iX++)
                {
                    switch (spaces[iX,iY])
                    {
                        case Victim spase:      Console.Write("()");
                                                healfPlayer = spase.Live;
                                                energyPlayer = spase.Energy;
                                                break;

                        case Personage spase:   Console.Write("<>"); break;

                        case Bonus spase:       Console.Write("oo"); break;

                        case Space spase:       Console.Write("##"); break;

                        default:                Console.Write("  "); break;
                    }
                }
                
                Console.WriteLine("|");
            }

            Console.WriteLine(new string('-', spaces.GetLength(0) * 2));

            Console.WriteLine(" () - Player");
            Console.WriteLine(" <> - Hunter");
            Console.WriteLine(" oo - Fruct");
        }

        public Visualisation()
        {
            consoleSimbol = ConsoleKey.UpArrow;

            secondThread = new Thread(ConsoleReader);
            secondThread.Start();

            healfPlayer = 0;
        }

        private static void ConsoleReader()
        {
            while (true)
            {
                consoleSimbol = Console.ReadKey(true).Key;
            }
        }
    }
}
