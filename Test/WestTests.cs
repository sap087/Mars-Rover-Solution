using MarsRover.Direction;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test {
    [TestFixture]
    public class WestTests
    {
        [Test]
        public void West_TurnLeft_returns_South()
        {
            IDirection currentDirection = new West();
            Assert.That(currentDirection.TurnLeft(), Is.TypeOf(typeof(South)));
        }
        
        [Test]
        public void West_TurnRight_returns_North()
        {
            IDirection currentDirection = new West();
            Assert.That(currentDirection.TurnRight(), Is.TypeOf(typeof(North)));
        }

        [TestCase(0, 0, -1)]
        [TestCase(3, 4, 2)]
        public void West_MoveFromCurrentPosition_ReturnsNewCoordinate_WithXMovedBackward(
         int currentX, int currentY, int newX)
        {
            Coordinates currentPosition = new Coordinates(currentX, currentY);
            IDirection currentDirection = new West();
            Coordinates newCoordinates = currentDirection.MoveFrom(currentPosition);
            Assert.AreEqual(newCoordinates.XCoordinate, newX);
            Assert.AreEqual(newCoordinates.YCoordinate, currentY);
        }
    }

}

