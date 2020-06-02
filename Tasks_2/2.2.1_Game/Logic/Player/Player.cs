using System;

namespace Game.Logic
{
    internal class Player : Victim
    {
        private Space[,] matrix;

        public override void Step(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.UpArrow:

                    if (IsStepTo(ConsoleKey.UpArrow))
                    {
                        if (matrix[X, Y - 1] is Bonus)
                        {
                            Energy += (matrix[X, Y - 1] as Bonus).Energy;
                        }

                        matrix[X, --Y] = matrix[X, Y + 1];
                        matrix[X, Y + 1] = null;
                    }
                    break;

                case ConsoleKey.DownArrow:

                    if (IsStepTo(ConsoleKey.DownArrow))
                    {
                        if (matrix[X, Y + 1] is Bonus)
                        {
                            Energy += (matrix[X, Y + 1] as Bonus).Energy;
                        }

                        matrix[X, ++Y] = matrix[X, Y - 1];
                        matrix[X, Y - 1] = null;
                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (IsStepTo(ConsoleKey.LeftArrow))
                    {
                        if (matrix[X - 1, Y] is Bonus)
                        {
                            Energy += (matrix[X - 1, Y] as Bonus).Energy;
                        }

                        matrix[--X, Y] = matrix[X + 1, Y];
                        matrix[X + 1, Y] = null;
                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (IsStepTo(ConsoleKey.RightArrow))
                    {
                        if (matrix[X + 1, Y] is Bonus)
                        {
                            Energy += (matrix[X + 1, Y] as Bonus).Energy;
                        }

                        matrix[++X, Y] = matrix[X - 1, Y];
                        matrix[X - 1, Y] = null;
                    }
                    break;

                default:
                    break;
            }
        }

        public override void Step()
        {
            Step(ConsoleKey.UpArrow);
        }

        public Player(int x, int y, Space[,] matrix)
        {
            X = x;
            Y = y;

            Live = 5;

            this.matrix = matrix;
        }

        private bool IsStepTo(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:

                    if (Y == 0)
                    {
                        return false;
                    }

                    switch (matrix[X, Y - 1])
                    {
                        case Bonus bonus: return true;

                        case Personage personage:
                        case Space space: return false;

                        default: return true;
                    }


                case ConsoleKey.DownArrow:

                    if (Y == matrix.GetLength(1) - 1)
                    {
                        return false;
                    }

                    switch (matrix[X, Y + 1])
                    {
                        case Bonus bonus: return true;

                        case Personage personage:
                        case Space space: return false;

                        default: return true;
                    }

                case ConsoleKey.LeftArrow:

                    if (X == 0)
                    {
                        return false;
                    }

                    switch (matrix[X - 1, Y])
                    {
                        case Bonus bonus: return true;

                        case Personage personage:
                        case Space space: return false;

                        default: return true;
                    }

                case ConsoleKey.RightArrow:

                    if (X == matrix.GetLength(0) - 1)
                    {
                        return false;
                    }

                    switch (matrix[X + 1, Y])
                    {
                        case Bonus bonus: return true;

                        case Personage personage:
                        case Space space: return false;

                        default: return true;
                    }

                default:
                    throw new ArgumentException("Incorrect argument!");
            }
        }
    }
}
