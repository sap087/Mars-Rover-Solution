namespace MarsRover
{
    public class Grid : IGrid
    {
        public Grid(Coordinates bottomLeftCoordinates, Coordinates topRightCoordinates)
        {
            BottomLeftCoordinates = bottomLeftCoordinates;
            TopRightCoordinates = topRightCoordinates;
        }

        public Coordinates BottomLeftCoordinates { get; }
        public Coordinates TopRightCoordinates { get; }
        public bool IsWithinGrid(Coordinates coordinates)
        {
            return coordinates.IsOutsideBound(BottomLeftCoordinates) && 
                coordinates.IsInsideBound(TopRightCoordinates);
        }
    }
}
