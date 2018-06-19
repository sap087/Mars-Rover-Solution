using MarsRover.Interfaces;

namespace MarsRover.Direction
{
    /// <summary>
    /// <see cref="IDirection"/>
    /// </summary>
    public class West : IDirection
    {
        public IDirection TurnLeft()
        {
            return new South();
        }

        public IDirection TurnRight()
        {
            return new North();
        }

        public Coordinates MoveFrom(Coordinates currentPosition)
        {
            return currentPosition.MoveXBackward();
        }

        public override string ToString()
        {
            return "West";
        }
    }
}
