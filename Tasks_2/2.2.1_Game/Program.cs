using System;
using System.Collections.Generic;
using System.Threading;
using Game.Logic;
using Game.Visualization;


namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            new World();
        }
    }


    class World
    {
        Visualisation visualisation;

        Space[,] matrix;

        List<Victim> victim;
        List<Personage> personage;
        List<Bonus> bonus;

        public World()
        {
            matrix = new Space[20, 10];

            visualisation = new Visualisation();

            InitializeMatrix();

            Start();
        }

        public void Start()
        {
            while (true)
            {
                foreach (var item in victim)
                {
                    StepPersonage(item);
                }

                foreach (var item in personage)
                {
                    StepPersonage(item);
                }

                visualisation.ShowMatrix(matrix);

                Thread.Sleep(1000);
            }
        }

        private void InitializeMatrix()
        {    
            for (int iX = 1; iX < 9; iX++)
            {
                matrix[iX, 1] = new Logic.Barrier();
                matrix[iX, 8] = new Logic.Barrier();
            }

            for (int iX = 11; iX < 19; iX++)
            {
                matrix[iX, 1] = new Logic.Barrier();
                matrix[iX, 8] = new Logic.Barrier();
            }

            for (int iY = 2; iY < 4; iY++)
            {
                matrix[1, iY] = new Logic.Barrier();
                matrix[18, iY] = new Logic.Barrier();
            }

            for (int iY = 6; iY < 8; iY++)
            {
                matrix[1, iY] = new Logic.Barrier();
                matrix[18, iY] = new Logic.Barrier();
            }

            for (int iX = 6; iX < 14; iX++)
            {
                matrix[iX, 4] = new Logic.Barrier();
                matrix[iX, 5] = new Logic.Barrier();
            }


            victim = new List<Victim>()
            {
                new Player(9, 9, matrix)
            };
            matrix[9, 9] = victim[0];
            
            personage = new List<Personage>()
            {
                new Hunter(0, 0, matrix, victim[0]),
                new Hunter(9, 0, matrix, victim[0]),
                new Hunter(19, 0, matrix, victim[0])
            };
            matrix[0, 0] = personage[0];
            matrix[9, 0] = personage[1];
            matrix[19, 0] = personage[2];

            bonus = new List<Bonus>()
            {
                new Fruct(2, 6),
                new Fruct(17, 3),
                new Fruct(10, 3)
            };
            matrix[2, 6] = bonus[0];
            matrix[17, 3] = bonus[1];
            matrix[10, 3] = bonus[2];
        }

        private void StepPersonage(Personage personage)
        {
            switch (personage)
            {
                case Victim victim:
                    victim.Step(visualisation.ConsoleSimbol);
                    break;

                case Hunter person:
                    person.Step();
                    break;

                default:
                    break;
            }
        }
    }
}
