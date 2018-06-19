namespace MarsRover.Interfaces
{
    /// <summary>
    /// Interface to represents four possible direction. Each direction is aware of its left and
    /// right direction and can return a new position when moved one step in this direction.
    /// </summary>
    public interface IDirection
    {
        IDirection TurnLeft();

        IDirection TurnRight();

        Coordinates MoveFrom(Coordinates currentPosition);
    }
}
