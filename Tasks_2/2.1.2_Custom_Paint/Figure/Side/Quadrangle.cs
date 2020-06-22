using System;
using System.Text;

namespace _2._1._2_Custom_Paint.Figure.Side
{
    internal class Quadrangle : AbstractPoligon
    {
        public Quadrangle(params AbstractSide[] sides) : this(0, 0, sides)
        {

        }
        public Quadrangle(int centreX, int centreY, params AbstractSide[] sides) : this(centreX, centreY)
        {
            foreach (var item in sides)
            {
                _sides.Add(item);
            }
        }
        protected Quadrangle(int centreX, int centreY)
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
                    case 1:         return (int)Math.Pow(_sides[0].Long, 2);
                    case 2:         return _sides[0].Long * _sides[1].Long;

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
                    case 1:         return (int)(Math.PI * _sides[0].Long);
                    case 2:         return (int)(Math.Pow(_sides[0].Long + _sides[1].Long, 2) * Math.PI);

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
                        if (iY == 0 || iY == _sides[0].Long - 1)
                        {
                            builder.Append(new string(point, _sides[0].Long * 2));
                            builder.Append(Environment.NewLine);
                        }
                        else
                        {
                            builder.Append(point + new string(space, (_sides[0].Long - 1) * 2) + point);
                            builder.Append(Environment.NewLine);
                        }
                    }

                    break;

                case 2:

                    for (int iY = 0; iY < _sides[1].Long; iY++)
                    {
                        if (iY == 0 || iY == _sides[1].Long - 1)
                        {
                            builder.Append(new string(point, _sides[0].Long * 2));
                            builder.Append(Environment.NewLine);
                        }
                        else
                        {
                            builder.Append(point + new string(space, (_sides[0].Long - 1) * 2) + point);
                            builder.Append(Environment.NewLine);
                        }
                    }

                    break;

                default:
                    break;
            }

            return builder.ToString();
        }
    }
}
