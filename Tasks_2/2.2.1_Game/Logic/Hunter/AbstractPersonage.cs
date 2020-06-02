namespace Game.Logic
{
    internal abstract class Personage : Space
    {
        public new int X { get; protected set; }
        public new int Y { get; protected set; }

        public int Energy { get; protected set; }

        public abstract void Step();
    }
}
