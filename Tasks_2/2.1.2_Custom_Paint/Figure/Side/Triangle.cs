using System;
using System.Text;

namespace _2._1._2_Custom_Paint.Figure.Side
{
    internal class Triangle : AbstractPoligon
    {
        public Triangle(params AbstractSide[] sides) : this(0, 0, sides)
        {

        }
        public Triangle(int centreX, int centreY, params AbstractSide[] sides) : this(centreX, centreY)
        {
            foreach (var item in sides)
            {
                _sides.Add(item);
            }
        }
        protected Triangle(int centreX, int centreY)
        {
            _centreX = centreX;
            _centreY = centreY;

            _sides = new System.Collections.Generic.List<AbstractSide>();
        }

        public override int Aria
        {
            get
            {
                switch (_sides.Count)
                {
                    case 1:         return (int)(Math.Pow(_sides[0].Long, 2) * Math.Sqrt(3)) / 4;
                    case 2:         return (_sides[0].Long * _sides[1].Long) / 2;

                    default:        return 0;
                }
            }
        }
        public override int Circumference
        {
            get
            {
                switch (_sides.Count)
                {
                    case 1:         return (int)(2 * Math.PI * _sides[0].Long / Math.Sqrt(3));
                    case 2:         return (int)((Math.Sqrt(Math.Pow(_sides[0].Long + _sides[1].Long, 2)) / 2) * Math.PI * 2);

                    default:        return 0;
                }
            }
        }

        public override string ToString()
        {
            const char space = ' ';
            const char point = 'O';

            StringBuilder builder = new StringBuilder();

            switch (_sides.Count)
            {
                case 1:

                    for (int iY = 0; iY < _sides[0].Long; iY++)
                    {

                        if (iY == 0)
                        {
                            builder.Append(new string(space, _sides[0].Long - 1) +
                                           new string(point, 2));
                        }
                        else if (iY == _sides[0].Long - 1)
                        {
                            builder.Append(new string(point, _sides[0].Long * 2));
                        }
                        else
                        {
                            builder.Append(new string(space, _sides[0].Long - iY - 1) +
                                           point +
                                           new string(space, iY * 2) +
                                           point);
                        }

                        builder.Append(Environment.NewLine);
                    }

                    break;

                case 2 :

                    int coeficient1 = _sides[1].Long % 2 == 0 ? 1 : 0;

                    for (int iY = 0, count = 0; iY < _sides[1].Long; iY++, count++)
                    {

                        builder.Append(point);

                        if (iY > 0)
                        {
                            if ((_sides[1].Long - 1) / 4 == iY)
                            {
                                builder.Append(new string(space, (_sides[0].Long * 2 - 2) / 4) + point);
                            }
                            if (((_sides[1].Long - 1) / 4 + (_sides[1].Long - 1) / 2) == iY)
                            {
                                builder.Append(new string(space, (_sides[0].Long * 2 - 2) / 4 + (_sides[0].Long * 2 - 2) / 2) + point);
                            }
                            if (iY == _sides[1].Long - 1)
                            {
                                builder.Append(new string(point, _sides[0].Long * 2 - 1));
                            }
                        }

                        builder.Append(Environment.NewLine);
                    }

                    break;

                default:
                    break;
            }

            return builder.ToString();
        }
    }
}
