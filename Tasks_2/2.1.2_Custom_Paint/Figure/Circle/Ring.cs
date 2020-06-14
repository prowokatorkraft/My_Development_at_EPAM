using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace _2._1._2_Custom_Paint.Figure.Circle
{
    internal class Ring : AbstractFigure
    {
        private AbstractCircle _outCircle;
        private AbstractCircle _inCircle;

        public Ring(AbstractCircle outCircle, AbstractCircle inCircle) : this(outCircle, inCircle, 0, 0)
        {

        }
        public Ring(AbstractCircle outCircle, AbstractCircle inCircle, int centreX, int centreY)
        {
            _centreX = centreX;
            _centreY = centreY;

            _outCircle = outCircle;
            _inCircle = inCircle;
        }

        public override int Aria
        {
            get => _outCircle.Aria;
        }
        public override int Circumference
        {
            get => _outCircle.Circumference + _inCircle.Circumference;
        }

        public override string ToString()
        {
            string[] outStr = _outCircle.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] inStr = _inCircle.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            int inStrToOutStrIndex = (outStr.Length / 2) - (inStr.Length / 2);
            int interSize;

            for (int iY = 0; iY < outStr.Length; iY++)
            {
                if (iY >= inStrToOutStrIndex && iY < inStrToOutStrIndex + inStr.Length)
                {
                    if (outStr[iY].Length > inStr[iY - inStrToOutStrIndex].Length)
                    {
                        interSize = (outStr[iY].Length - inStr[iY - inStrToOutStrIndex].Length) / 2;

                        outStr[iY] = Regex.Replace(outStr[iY],
                            "(?<a>\\D{" + interSize + "})(?<b>\\D{" + inStr[iY - inStrToOutStrIndex].Length + "})(?<c>\\D{" + interSize + "})",
                            "${a}" + inStr[iY - inStrToOutStrIndex] + "${c}"
                            );
                    }
                    else
                    {
                        outStr[iY] = new string(' ', inStrToOutStrIndex * 2) + inStr[iY - inStrToOutStrIndex];
                    }
                }
            }

            StringBuilder builder = new StringBuilder();

            foreach (var item in outStr)
            {
                builder.Append(item);
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }


        //public override string ToString()
        //{
        //    string[] outStr = _outCircle.ToString().Split('\n');
        //    string[] inStr = _inCircle.ToString().Split('\n');

        //    int interSize = (outStr[7].Length - inStr[3].Length) / 2;

        //    outStr[7] = Regex.Replace(outStr[7], 
        //        "(?<a>\\D{" + interSize + "})(?<b>\\D{" + inStr[3].Length + "})(?<c>\\D{" + interSize + "})", 
        //        "${a}" + inStr[3].TrimEnd('\r') + "${c}"
        //        );

        //    Console.WriteLine($"out: {outStr[7].Length}, in: {inStr[3].Length}");


        //    return outStr[7];
        //}

        //public override string ToString()
        //{
        //    string[] outStr = _outCircle.ToString().Split('\n');
        //    string[] inStr = _inCircle.ToString().Split('\n');

        //    StringBuilder builder = new StringBuilder();

        //    int inStrToOutStrIndex = (outStr.Length / 2) - (inStr.Length / 2);

        //    for (int iY = 0; iY < outStr.Length; iY++)
        //    {
        //        for (int iX = 0; iX < outStr[iY].Length; iX++)
        //        {
        //            if ((iY >= inStrToOutStrIndex && iY < inStr.Length) && (iX >= inStrToOutStrIndex && iX < inStr.Length))
        //            {
        //                string s1 = outStr[iY].Substring(0);
        //                string s2 = inStr[iY - inStrToOutStrIndex];

        //                builder.Append(s1);

        //                builder.Append(s2);

        //                continue;

        //                //builder.Append(inStr[iY - inStrToOutStrIndex] + outStr[iY].Substring(inStr[iY - inStrToOutStrIndex].Length));
        //            }
        //            else if (iY >= inStrToOutStrIndex && iY < inStr.Length)
        //            {

        //            }
        //            else if (iX >= inStrToOutStrIndex && iX < inStr.Length)
        //            {

        //            }
        //            else
        //            {
        //                builder.Append(outStr[iY]);
        //                continue;
        //            }
        //        }

        //        builder.Append(Environment.NewLine);
        //    }

        //    return builder.ToString();
        //}
    }
}
