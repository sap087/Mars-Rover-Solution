using MarsRover.Interfaces;

namespace MarsRover
{
    public class MarsRover : IRover
    {
        private readonly IGrid grid;
        public MarsRover(IDirection startDirection, Coordinates startCoordinates, IGrid grid)
        {
            this.grid = grid;
            CurrentDirection = startDirection;
            CurrentPosition = startCoordinates;
        }

        public void RotateLeft()
        {
            CurrentDirection = CurrentDirection.TurnLeft();
        }

        public void RotateRight()
        {
            CurrentDirection = CurrentDirection.TurnRight();
        }

        public void MoveFoward()
        {
            Coordinates newCoordinates = CurrentDirection.MoveFrom(CurrentPosition);
            if (grid.IsWithinGrid(newCoordinates))
            {
                CurrentPosition = newCoordinates;
            }
        }

        public void RunCommands(string stringCommands)
        {
            CommandParser parser = new CommandParser(stringCommands);
            foreach (ICommand command in parser.BuildCommandsList())
            {
                command.Execute(this);
            }
        }

        public Coordinates CurrentPosition { get; private set; }
        public IDirection CurrentDirection { get; private set; }

        public override string ToString()
        {
            return string.Format(
                "X-Coordinate : {0}, " +
                "Y-Coordinate : {1}, " +
                "Direction : {2} ",
                CurrentPosition.XCoordinate,
                CurrentPosition.YCoordinate,
                CurrentDirection);
        }
    }
}
