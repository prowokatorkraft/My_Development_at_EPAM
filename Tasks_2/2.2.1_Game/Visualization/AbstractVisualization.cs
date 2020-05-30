using System;

namespace Game.Visualization
{
    interface IVisual
    {
        ConsoleKey ConsoleSimbol { get; }

        void ShowMatrix(Logic.Space[,] spaces);
    }
}
