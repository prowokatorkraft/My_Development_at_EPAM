
namespace Game.Logic
{
    abstract class Personage : ILocation
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public int Energy { get; protected set; }

        public abstract void Step();
    }

    abstract class Victim : Personage
    {
        public int Live { get; protected set; }

        public abstract void Step(Direction direction);
    }


    abstract class Object : ILocation
    {
        public int X { get; }
        public int Y { get; }
    }

    abstract class Bonus : Object
    {
        public int Energy { get; }
    }



    public interface ILocation
    {
        int X { get; }
        int Y { get; }
    }

    enum Direction
    {
        Up, Down, Left, Right
    }
}
