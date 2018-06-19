using MarsRover.Direction;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class SouthTest
    {
        [Test]
        public void South_TurnLeft_returns_East()
        {
            IDirection currentDirection = new South();
            Assert.That(currentDirection.TurnLeft(), Is.TypeOf(typeof(East)));
        }
        [Test]
        public void South_TurnRight_returns_West()
        {
            IDirection currentDirection = new South();
            Assert.That(currentDirection.TurnRight(), Is.TypeOf(typeof(West)));
        }

        [TestCase(0, 0, -1)]
        [TestCase(3, 4, 3)]
        public void South_MoveFromCurrentPosition_ReturnsNewCoordinate_WithYMovedDownward(
          int currentX, int currentY, int newY)
        {
            Coordinates currentPosition = new Coordinates(currentX, currentY);
            IDirection currentDirection = new South();
            Coordinates newCoordinates = currentDirection.MoveFrom(currentPosition);
            Assert.AreEqual(newCoordinates.XCoordinate, currentX);
            Assert.AreEqual(newCoordinates.YCoordinate, newY);
        }

     }
}
