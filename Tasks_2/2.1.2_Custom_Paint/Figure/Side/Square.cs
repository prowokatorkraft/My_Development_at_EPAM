using System;
using System.Text;

namespace _2._1._2_Custom_Paint.Figure.Side
{
    internal class Square : AbstractPoligon
    {
        public Square(int size) : this(0, 0, size)
        {

        }
        public Square(int centreX, int centreY, int size)
        {
            _centreX = centreX;
            _centreY = centreY;

            _sides = new System.Collections.Generic.List<AbstractSide>();

            _sides.Add(new Side(size));
        }

        public override int Aria
        {
            get => (int)Math.Pow(_sides[0].Long, 2);
        }
        public override int Circumference
        {
            get => (int)(Math.PI * _sides[0].Long);
        }

        public override string ToString()
        {
            const char space = ' ';
            const char point = 'O';

            StringBuilder builder = new StringBuilder();

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

            return builder.ToString();
        }
    }
}
