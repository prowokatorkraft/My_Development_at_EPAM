using System;

namespace Game.Logic
{
    class Barrier : Space
    {
        
    }

    class Hunter : Personage
    {
        private Victim victim;
        private Space[,] matrix;
        ConsoleKey direction;

        public override void Step()
        {
            direction = DirectToVictim();

            switch (direction)
            {
                case ConsoleKey.UpArrow:

                    if (IsStepTo(ConsoleKey.UpArrow))
                    {
                        if (matrix[X, Y - 1] is Victim)
                        {
                            Environment.Exit(0);
                        }

                        matrix[X, --Y] = matrix[X, Y + 1];
                        matrix[X, Y + 1] = null;
                    }
                    break;

                case ConsoleKey.DownArrow:

                    if (IsStepTo(ConsoleKey.DownArrow))
                    {
                        if (matrix[X, Y + 1] is Victim)
                        {
                            Environment.Exit(0);
                        }

                        matrix[X, ++Y] = matrix[X, Y - 1];
                        matrix[X, Y - 1] = null;
                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (IsStepTo(ConsoleKey.LeftArrow))
                    {
                        if (matrix[X - 1, Y] is Victim)
                        {
                            Environment.Exit(0);
                        }

                        matrix[--X, Y] = matrix[X + 1, Y];
                        matrix[X + 1, Y] = null;
                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (IsStepTo(ConsoleKey.RightArrow))
                    {
                        if (matrix[X + 1, Y] is Victim)
                        {
                            Environment.Exit(0);
                        }

                        matrix[++X, Y] = matrix[X - 1, Y];
                        matrix[X - 1, Y] = null;
                    }
                    break;

                default:
                    break;
            }

        }

        public Hunter(int x, int y, Space[,] matrix, Victim victim)
        {
            X = x;
            Y = y;

            this.victim = victim;
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
                        case Victim victim:
                        case Bonus bonus: return true;
                        case Personage personage:
                        case Space space: return false;

                        default: return true;
                    }


                case ConsoleKey.DownArrow:

                    if (Y == 9) ////
                    {
                        return false;
                    }

                    switch (matrix[X, Y + 1])
                    {
                        case Victim victim:
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
                        case Victim victim:
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
                        case Victim victim:
                        case Bonus bonus: return true;
                        case Personage personage:
                        case Space space: return false;

                        default: return true;
                    }

                default:
                    throw new ArgumentException("Incorrect argument!");
            }
        }

        private ConsoleKey DirectToVictim()
        {
            int differentX = X - victim.X;////
            int differentY = Y - victim.Y;////

            int differ = 0;

            ConsoleKey key;

            if ((differentX > 0 ? differentX : differentX * -1)  >  (differentY > 0 ? differentY : differentY * -1))
            {
                differ = differentX > 0 ? -1 : 1;

                if (!(matrix[X + differ, Y] is Victim) && matrix[X + differ, Y] is Space)
                {
                    return differentY > 0 ? ConsoleKey.UpArrow : ConsoleKey.DownArrow;
                }
                else
                {
                    return key = differentX > 0 ? ConsoleKey.LeftArrow : ConsoleKey.RightArrow;
                }
            }
            else
            {
                differ = differentY > 0 ? -1 : 1;

                if (!(matrix[X, Y + differ] is Victim) && matrix[X, Y + differ] is Space)
                {
                    return key = differentX > 0 ? ConsoleKey.LeftArrow : ConsoleKey.RightArrow;
                }
                else
                {
                    return differentY > 0 ? ConsoleKey.UpArrow : ConsoleKey.DownArrow;
                }
            }
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
            Energy = 100;
        }
    }
}
