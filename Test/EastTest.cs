using MarsRover.Direction;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test
{

    [TestFixture]
    public class EastTest
    {
        [Test]
        public void East_TurnLeft_returns_North()
        {
            IDirection currentDirection = new East();
            Assert.That(currentDirection.TurnLeft(), Is.TypeOf(typeof(North)));
        }

        [Test]
        public void East_TurnRight_returns_South()
        {
            IDirection currentDirection = new East();
            Assert.That(currentDirection.TurnRight(), Is.TypeOf(typeof(South)));
        }

        [TestCase(0, 0, 1)]
        [TestCase(3, 4, 4)]
        public void East_MoveFromCurrentPosition_ReturnsNewCoordinate_WithXMovedForward(
            int currentX, int currentY, int newX)
        {
            Coordinates currentPosition = new Coordinates(currentX, currentY);
            IDirection currentDirection = new East();
            Coordinates newCoordinates = currentDirection.MoveFrom(currentPosition);
            Assert.AreEqual(newCoordinates.XCoordinate, newX);
            Assert.AreEqual(newCoordinates.YCoordinate, currentY);
        }
    }
}
