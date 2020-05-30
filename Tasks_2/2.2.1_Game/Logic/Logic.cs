using System;

namespace Game.Logic
{
    class Barrier : Space
    {
        
    }

    class Hunter : Personage
    {
        public override void Step()
        {
            throw new NotImplementedException();
        }

        public Hunter(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Player : Victim
    {
        private Space[,] matrix;

        public override void Step(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.UpArrow:

                    if (IsStepTo(ConsoleKey.UpArrow))
                    {
                        /// bonus
                        matrix[X, --Y] = matrix[X, Y + 1];
                        matrix[X, Y + 1] = null;
                    }
                    break;

                case ConsoleKey.DownArrow:

                    if (IsStepTo(ConsoleKey.DownArrow))
                    {
                        /// bonus
                        matrix[X, ++Y] = matrix[X, Y - 1];
                        matrix[X, Y - 1] = null;
                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (IsStepTo(ConsoleKey.LeftArrow))
                    {
                        /// bonus
                        matrix[--X, Y] = matrix[X + 1, Y];
                        matrix[X + 1, Y] = null;
                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (IsStepTo(ConsoleKey.RightArrow))
                    {
                        /// bonus
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
                        case Bonus bonus:           return true;
                        case Personage personage:
                        case Space space:           return false;

                        default:                    return true;
                    }


                case ConsoleKey.DownArrow:

                    if (Y == 9) ////
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

                    if (X == 19)
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

    class Fruct : Bonus
    {
        public Fruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
