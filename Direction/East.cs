using MarsRover.Interfaces;

namespace MarsRover.Direction
{
    /// <summary>
    /// <see cref="IDirection"/>
    /// </summary>
    public class East : IDirection
    {
        public IDirection TurnLeft()
        {
            return new North();
        }

        public IDirection TurnRight()
        {
            return new South();
            
        }

        public Coordinates MoveFrom(Coordinates currentPosition)
        {
            return currentPosition.MoveXForward();
        }

        public override string ToString()
        {
            return "East";
        }
    }
}
