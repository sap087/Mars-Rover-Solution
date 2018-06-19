using MarsRover.Interfaces;

namespace MarsRover
{
    public interface IRover
    {
        void RotateLeft();
        void RotateRight();
        void MoveFoward();
        void RunCommands(string stringCommands);
        Coordinates CurrentPosition { get;}
        IDirection CurrentDirection { get; }
    }
}
