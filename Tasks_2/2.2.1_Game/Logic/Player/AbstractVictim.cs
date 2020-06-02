namespace Game.Logic
{
    internal abstract class Victim : Personage
    {
        public int Live { get; protected set; }

        public abstract void Step(System.ConsoleKey direction);
    }
}
