namespace MarsRover.Interfaces
{
    /// <summary>
    /// Interface for executing a <see cref="IRover"/> operation
    /// </summary>
    public interface ICommand
    {
        void Execute(IRover rover);
    }
}
