using MarsRover.Interfaces;

namespace MarsRover.Commands
{
    /// <summary>
    /// Implements the MoveForward  operation on the <see cref="IRover"/>
    /// </summary>
    class MoveForwardCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.MoveFoward();
        }
    }
}
