using MarsRover.Interfaces;

namespace MarsRover.Commands
{
    /// <summary>
    /// Implements the RotateLeft operation on the <see cref="IRover"/>
    /// </summary>
    class RotateLeftCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.RotateLeft();
        }
    }
}
