using MarsRover.Direction;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test
{

    [TestFixture]
    public class NorthTest
    {
        [Test]
        public void North_TurnLeft_returns_West()
        {
            IDirection currentDirection = new North();
            Assert.That(currentDirection.TurnLeft(), Is.TypeOf(typeof(West)));
        }

        [Test]
        public void North_TurnRight_returns_East()
        {
            IDirection currentDirection = new North();
            Assert.That(currentDirection.TurnRight(), Is.TypeOf(typeof(East)));
        }

        [TestCase(0, 0, 1)]
        [TestCase(3, 4, 5)]
        public void North_MoveFromCurrentPosition_ReturnsNewCoordinate_WithYMovedUpward(
            int currentX, int currentY, int newY)
        {
            Coordinates currentPosition = new Coordinates(currentX, currentY);
            IDirection currentDirection = new North();
            Coordinates newCoordinates = currentDirection.MoveFrom(currentPosition);
            Assert.AreEqual(newCoordinates.XCoordinate, currentX);
            Assert.AreEqual(newCoordinates.YCoordinate, newY);
        }
    
    }
}
