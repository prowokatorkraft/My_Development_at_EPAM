using System;
using System.Text;

namespace _2._1._2_Custom_Paint.Figure.Side
{
    internal class Triangle : AbstractPoligon
    {
        public Triangle(int size) : this(0, 0, size)
        {

        }
        public Triangle(int centreX, int centreY, int size)
        {
            _centreX = centreX;
            _centreY = centreY;

            _sides = new System.Collections.Generic.List<AbstractSide>();

            _sides.Add(new Side(size));
        }

        public override int Aria
        {
            get => (int)(Math.Pow(_sides[0].Long, 2) * Math.Sqrt(3)) / 4;
        }
        public override int Circumference
        {
            get => (int)(2 * Math.PI * _sides[0].Long / Math.Sqrt(3));
        }

        public override string ToString()
        {
            const char space = ' ';
            const char point = 'O';

            StringBuilder builder = new StringBuilder();

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

            return builder.ToString();
        }
    }
}
