using MarsRover.Interfaces;

namespace MarsRover.Direction
{
    /// <summary>
    /// <see cref="IDirection"/>
    /// </summary>
    public class South : IDirection
    {
        public IDirection TurnLeft()
        {
           return new East();
        }

        public IDirection TurnRight()
        {
           return new West();
        }

        public Coordinates MoveFrom(Coordinates currentPosition)
        {
            return currentPosition.MoveYDownwards();
        }

        public override string ToString()
        {
            return "South";
        }
    }
}
