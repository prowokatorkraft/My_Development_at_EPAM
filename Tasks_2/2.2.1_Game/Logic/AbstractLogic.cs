
namespace Game.Logic
{
    abstract class Space
    {
        public int X { get; }
        public int Y { get; }
    }

    abstract class Personage : Space
    {
        public new int X { get; protected set; }
        public new int Y { get; protected set; }

        public int Energy { get; protected set; }

        public abstract void Step();
    }

    abstract class Victim : Personage
    {
        public int Live { get; protected set; }

        public abstract void Step(System.ConsoleKey direction);
    }



    abstract class Bonus : Space
    {
        public new int X { get; protected set; }
        public new int Y { get; protected set; }

        public int Energy { get; protected set; }
    }
}
