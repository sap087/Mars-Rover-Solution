using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void Grid_InitializeWith_bottomLeft00_topRight11()
        {
            Grid grid = new Grid(new Coordinates(0,0), new Coordinates(2,2));
            Assert.That(grid.TopRightCoordinates.XCoordinate == 2);
            Assert.That(grid.TopRightCoordinates.YCoordinate == 2);
            Assert.That(grid.BottomLeftCoordinates.XCoordinate == 0);
            Assert.That(grid.BottomLeftCoordinates.YCoordinate == 0);
        }

        [TestCase(2, 3, 5, 5, true)]
        [TestCase(0, 2, 3, 4, true)]
        [TestCase(0, 0, 2, 3, true)]
        [TestCase(5, 5, 5, 5, true)]
        [TestCase(0, 5, 5, 5, true)]
        [TestCase(5, 0, 5, 5, true)]
        [TestCase(6, 6, 5, 5, false)]
        [TestCase(5, 6, 5, 5, false)]
        [TestCase(6, 5, 5, 5, false)]
        [TestCase(-1, 0, 5, 5, false)]
        [TestCase(0, -1, 5, 5, false)]
        public void IsWithinGrid_ChecksGivenPositionIsWithinGrid(
            int posX, int posY, int gridWidth, int gridLength, bool result
            )
        {
            Grid grid = new Grid(new Coordinates(0, 0), new Coordinates(gridWidth, gridLength));
            bool isWithinGrid = grid.IsWithinGrid(new Coordinates(posX, posY));
            Assert.AreEqual(isWithinGrid, result);
        }
    }
}
