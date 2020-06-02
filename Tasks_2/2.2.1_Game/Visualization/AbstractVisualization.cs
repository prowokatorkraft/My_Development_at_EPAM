using System;

namespace Game.Visualization
{
    internal interface IVisual
    {
        ConsoleKey ConsoleSimbol { get; }

        void ShowMatrix(Logic.Space[,] spaces);
    }
}
