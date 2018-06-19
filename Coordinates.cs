namespace MarsRover
{
    /// <summary>
    /// An immutable object that represents a X and Y coordinates to reflect the position of a
    ///  <see cref="IRover"/> in <see cref="IGrid"/> 
    /// </summary>
    public class Coordinates
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public Coordinates(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public Coordinates MoveXForward()
        {
            return new Coordinates(XCoordinate + 1, YCoordinate);
        }

        public Coordinates MoveYUpward()
        {
            return new Coordinates(XCoordinate, YCoordinate + 1);
        }

        public Coordinates MoveXBackward()
        {
            return new Coordinates(XCoordinate - 1, YCoordinate);
        }

        public Coordinates MoveYDownwards()
        {
            return new Coordinates(XCoordinate, YCoordinate - 1);
        }

        public bool IsOutsideBound(Coordinates coordinates)
        {
            return XCoordinate >= coordinates.XCoordinate && YCoordinate >= coordinates.YCoordinate;
        }

        public bool IsInsideBound(Coordinates coordinates)
        {
            return XCoordinate <= coordinates.XCoordinate && YCoordinate <= coordinates.YCoordinate;
        }
    }
}
