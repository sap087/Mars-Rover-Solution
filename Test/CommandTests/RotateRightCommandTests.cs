using MarsRover.Commands;
using MarsRover.Direction;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test.CommandTests
{
    public class RotateRightCommandTests
    {

        [Test]
        public void Rover_FacingNorth_AtPosition34_5x5Grid_TurnsEast()
        {
            Coordinates startPosition = new Coordinates(3, 4);
            IDirection currentDirection = new North();
            Grid grid = new Grid(new Coordinates(0, 0), new Coordinates(5, 5));
            IRover rover = new MarsRover(currentDirection, startPosition, grid);
            ICommand moveCommand = new RotateRightCommand();
            moveCommand.Execute(rover);
            Assert.That(rover.CurrentDirection, Is.TypeOf<East>());
            Assert.That(rover.CurrentPosition.XCoordinate == 3);
            Assert.That(rover.CurrentPosition.YCoordinate == 4);
        }
    }
}
