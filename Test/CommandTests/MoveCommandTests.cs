using MarsRover.Commands;
using MarsRover.Direction;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test.CommandTests
{
    [TestFixture]
    public class MoveCommandTests
    {
        [Test]
        public void Rover_FacingWest_AtPosition34_5x5Grid_MovesTo24Position()
        {
            Coordinates startPosition = new Coordinates(3,4);
            IDirection currentDirection = new West();
            Grid grid = new Grid(new Coordinates(0,0), new Coordinates(5,5));
            IRover rover = new MarsRover(currentDirection, startPosition, grid);
            ICommand moveCommand = new MoveForwardCommand();
            moveCommand.Execute(rover);
            Assert.That(rover.CurrentDirection, Is.TypeOf<West>());
            Assert.That(rover.CurrentPosition.XCoordinate == 2);
            Assert.That(rover.CurrentPosition.YCoordinate == 4);
        }
    }
}
