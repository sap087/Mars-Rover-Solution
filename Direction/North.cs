using MarsRover.Interfaces;

namespace MarsRover.Direction
{
    /// <summary>
    /// <see cref="IDirection"/>
    /// </summary>
    public class North : IDirection
    {
        public IDirection TurnLeft()
        {
            return  new West();
        }           

        public IDirection TurnRight()
        {
            return new East();
        }

        public Coordinates MoveFrom(Coordinates currentPosition)
        {
            return currentPosition.MoveYUpward();
        }

        public override string ToString()
        {
            return "North";
        }
    }
}
