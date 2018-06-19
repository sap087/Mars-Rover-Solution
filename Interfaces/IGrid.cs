namespace MarsRover
{
    /// <summary>
    /// Represents a simple coordinate grid system
    /// </summary>
    public interface IGrid
    {
        Coordinates BottomLeftCoordinates { get; }
        Coordinates TopRightCoordinates { get; }
        /// <summary>
        /// Checks if the <param name="coordinates"></param>  is a position within a grid
        /// </summary>
        bool IsWithinGrid(Coordinates coordinates);
    }
}
