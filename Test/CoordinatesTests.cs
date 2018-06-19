using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class CoordinatesTests
    {
        [TestCase(0, 0, 1)]
        [TestCase(4, 5, 5)]
        [TestCase(2, 0, 3)]
        public void MoveXAxisForward_FromGivenPosition_ReturnsCorrectCoordinate(int startX, int startY, int newX)
        {
            Coordinates coordinates = new Coordinates(startX, startY);
            Coordinates newCoordinates = coordinates.MoveXForward();
            Assert.AreEqual(newCoordinates.XCoordinate, newX);
            Assert.AreEqual(newCoordinates.YCoordinate, startY);
        }

        [TestCase(0, 0, 1)]
        [TestCase(4, 5, 6)]
        public void MoveYAxisForward_FromGivenPosition_ReturnsCorrectCoordinate(int startX, int startY, int newY)
        {
            Coordinates coordinates = new Coordinates(startX, startY);
            Coordinates newCoordinates = coordinates.MoveYUpward();
            Assert.AreEqual(newCoordinates.XCoordinate, startX);
            Assert.AreEqual(newCoordinates.YCoordinate, newY);
        }

        [TestCase(0, 0, -1)]
        [TestCase(4, 5, 3)]
        public void MoveXAxisBackwards_FromGivenPosition_ReturnsCorrectCoordinate(int startX, int startY, int newX)
        {
            Coordinates coordinates = new Coordinates(startX, startY);
            Coordinates newCoordinates = coordinates.MoveXBackward();
            Assert.AreEqual(newCoordinates.XCoordinate, newX);
            Assert.AreEqual(newCoordinates.YCoordinate, startY);
        }

        [TestCase(0, 0, -1)]
        [TestCase(4, 5, 4)]
        public void MoveYAxisDownwards_FromGivenPosition_ReturnsCorrectCoordinate(int startX, int startY, int newY)
        {
            Coordinates coordinates = new Coordinates(startX, startY);
            Coordinates newCoordinates = coordinates.MoveYDownwards();
            Assert.AreEqual(newCoordinates.XCoordinate, startX);
            Assert.AreEqual(newCoordinates.YCoordinate, newY);
        }

        [Test]
        public void CurrentPosition02_IsOutsideBound_00_ReturnsTrue()
        {
            Coordinates currentPosition = new Coordinates(0, 2);
            Assert.IsTrue(currentPosition.IsOutsideBound(new Coordinates(0, 0)));
        }

      
        [TestCase(0, 0, 0, 2, true)]
        [TestCase(2, 3, 4, 5, true)]
        [TestCase(4, 3, 4, 5, true)]
        [TestCase(2, 3, 2, 3, true)]
        [TestCase(5, 5, 1, 1, false)]
        [TestCase(5, 5, 1, 5, false)]
        [TestCase(5, 5, 5, 1, false)]
        public void IsOutsideBound_EvaluatesIfGivenPoisition_IsOutside(int bottomLeftX, int bottomLeftY, int givenX, int givenY, bool result)
        {
            Coordinates bottomCoordinates = new Coordinates(bottomLeftX, bottomLeftY);
            Coordinates givenPosition = new Coordinates(givenX, givenY);
            Assert.AreEqual(givenPosition.IsOutsideBound(bottomCoordinates), result);
        }

        [TestCase(5, 5, 0, 2, true)]
        [TestCase(5, 5, 5, 5, true)]
        [TestCase(5, 5, 4, 5, true)]
        [TestCase(5, 6, 4, 5, true)]
        [TestCase(5, 5, 5, 1, true)]
        [TestCase(5, 5, 1, 5, true)]
        [TestCase(0, 0, 2, 2, false)]
        [TestCase(4, 4, 6, 6, false)]
        [TestCase(5, 5, 6, 1, false)]
        [TestCase(5, 5, 1, 6, false)]
        public void IsInsideBound_EvaluatesIfGivenPoisition_IsInside(int topRightX, int topRightY, int givenX, int givenY, bool result)
        {
            Coordinates bottomCoordinates = new Coordinates(topRightX, topRightY);
            Coordinates givenPosition = new Coordinates(givenX, givenY);
            Assert.AreEqual(givenPosition.IsInsideBound(bottomCoordinates), result);
        }
    }
}
