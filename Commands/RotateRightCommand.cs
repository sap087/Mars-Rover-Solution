using MarsRover.Interfaces;

namespace MarsRover.Commands
{
    /// <summary>
    /// Implements the RotateRight operation on the <see cref="IRover"/>
    /// </summary>
    class RotateRightCommand : ICommand
    {
        public void Execute(IRover rover)
        {
           rover.RotateRight();
        }
    }
}
