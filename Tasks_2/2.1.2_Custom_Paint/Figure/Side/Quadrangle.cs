﻿using System;
using System.Text;

namespace _2._1._2_Custom_Paint.Figure.Side
{
    internal class Quadrangle : AbstractPoligon
    {
        public Quadrangle(int hight, int weight) : this(0, 0, hight, weight)
        {

        }
        public Quadrangle(int centreX, int centreY, int hight, int weight)
        {
            _centreX = centreX;
            _centreY = centreY;

            _sides = new System.Collections.Generic.List<AbstractSide>();

            _sides.Add(new Side(hight));
            _sides.Add(new Side(weight));
        }

        public override int Aria
        {
            get => _sides[0].Long * _sides[1].Long;
        }
        public override int Circumference
        {
            get => (int)(Math.Pow(_sides[0].Long + _sides[1].Long, 2) * Math.PI);
        }

        public override string ToString()
        {
            const char space = ' ';
            const char point = 'O';

            StringBuilder builder = new StringBuilder();

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

            return builder.ToString();
        }
    }
}
