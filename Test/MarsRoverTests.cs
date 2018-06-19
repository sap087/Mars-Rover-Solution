using System;
using System.CodeDom;
using MarsRover.Direction;
using MarsRover.Interfaces;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class MarsRoverTests
    {
        [Test]
        public void MarsRover_initialized_HasCorrectDirection()
        {
            IDirection direction = new East();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0,0), grid.Object);
            Assert.That(marsRover.CurrentDirection == direction);
        }

        [Test]
        public void MarsRover_initialized_HasCorrectCoordinates()
        {
            IDirection direction = new East();
            Mock<IGrid> grid = new Mock<IGrid>();
            Coordinates startCoordinates = new Coordinates(2, 3);
            MarsRover marsRover = new MarsRover(direction, startCoordinates, grid.Object);
            Assert.That(marsRover.CurrentPosition == startCoordinates);
        }

        [Test]
        public void MarsRover_CurrentDirectionIsNorth_RotateLeft_TurnsToWest()
        {
            
            IDirection direction = new North();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateLeft();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<West>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsNorth_RotateRight_TurnsToEast()
        {
            IDirection direction = new North();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateRight();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<East>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsSouth_RotateLeft_TurnsToEast()
        {
            IDirection direction = new South();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateLeft();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<East>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsSouth_RotateRight_TurnsToWest()
        {
            IDirection direction = new South();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateRight();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<West>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsEast_RotateLeft_TurnsToNorth()
        {
            IDirection direction = new East();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateLeft();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<North>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsEast_RotateRight_TurnsToSouth()
        {
            IDirection direction = new East();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateRight();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<South>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsWest_RotateLeft_TurnsToSouth()
        {
            IDirection direction = new West();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateLeft();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<South>());
        }

        [Test]
        public void MarsRover_CurrentDirectionIsWest_RotateRight_TurnsToNorth()
        {
            IDirection direction = new West();
            Mock<IGrid> grid = new Mock<IGrid>();
            MarsRover marsRover = new MarsRover(direction, new Coordinates(0, 0), grid.Object);
            marsRover.RotateRight();
            Assert.That(marsRover.CurrentDirection, Is.TypeOf<North>());
        }

        [TestCase(2, 3, 4)]
        [TestCase(4, 5, 5, Reason = "Rover has moved beyond the Grid boundary")]
        public void MarsRover_FacingNorth_MoveForward_MovesToCorrectPosition_And_StaysWithinGrid(
            int currentX, int currentY, int finalY)
        {
            IDirection direction = new North();
            Grid grid = new Grid(new Coordinates(0, 0), new Coordinates(5, 5));
            MarsRover marsRover = 
                new MarsRover(direction, new Coordinates(currentX, currentY), grid);
            marsRover.MoveFoward();
            Assert.AreEqual(marsRover.CurrentPosition.XCoordinate, currentX);
            Assert.AreEqual(marsRover.CurrentPosition.YCoordinate, finalY );
        }

        [TestCase(2, 3, 2)]
        [TestCase(4, 0, 0, Reason = "Rover has moved beyond the Grid boundary")]
        public void MarsRover_FacingSouth_MoveForward_MovesToCorrectPosition_And_StaysWithinGrid(
           int currentX, int currentY, int finalY)
        {
            IDirection direction = new South();
            Grid grid = new Grid(new Coordinates(0, 0), new Coordinates(5, 5));
            MarsRover marsRover =
                new MarsRover(direction, new Coordinates(currentX, currentY), grid);
            marsRover.MoveFoward();
            Assert.AreEqual(marsRover.CurrentPosition.XCoordinate, currentX);
            Assert.AreEqual(marsRover.CurrentPosition.YCoordinate, finalY);
        }

        [TestCase(2, 3, 3)]
        [TestCase(5, 2, 5, Reason = "Rover has moved beyond the Grid boundary")]
        public void MarsRover_FacingEast_MoveForward_MovesToCorrectPosition_And_StaysWithinGrid(
         int currentX, int currentY, int finalX)
        {
            IDirection direction = new East();
            Grid grid = new Grid(new Coordinates(0, 0), new Coordinates(5, 5));
            MarsRover marsRover =
                new MarsRover(direction, new Coordinates(currentX, currentY), grid);
            marsRover.MoveFoward();
            Assert.AreEqual(marsRover.CurrentPosition.XCoordinate, finalX);
            Assert.AreEqual(marsRover.CurrentPosition.YCoordinate, currentY);
        }

        [TestCase(2, 3, 1)]
        [TestCase(0, 2, 0, Reason = "Rover has moved beyond the Grid boundary")]
        public void MarsRover_FacingWest_MoveForward_MovesToCorrectPosition_And_StaysWithinGrid(
        int currentX, int currentY, int finalX)
        {
            IDirection direction = new West();
            Grid grid = new Grid(new Coordinates(0, 0), new Coordinates(5, 5));
            MarsRover marsRover =
                new MarsRover(direction, new Coordinates(currentX, currentY), grid);
            marsRover.MoveFoward();
            Assert.AreEqual(marsRover.CurrentPosition.XCoordinate, finalX);
            Assert.AreEqual(marsRover.CurrentPosition.YCoordinate, currentY);
        }
       
        [Test]
        public void TestRunCommands_RFLFFRF_On1x1Grid_StaysWithinGrid()
        {
            string stringCommand = "RFLFFRF";
            var startCoordinates = new Coordinates(0, 0);
            IDirection direction = new North();
            IGrid grid = new Grid(startCoordinates, new Coordinates(1, 1));
            IRover rover = new MarsRover(direction, startCoordinates, grid);
            rover.RunCommands(stringCommand);
            Assert.That(rover.CurrentPosition.XCoordinate == 1);
            Assert.That(rover.CurrentPosition.YCoordinate == 1);
            Assert.That(rover.CurrentDirection, Is.TypeOf<East>());
        }

        [TestCase("", 0, 0, 0, 0, typeof(North))]
        [TestCase(null, 0, 0, 0, 0, typeof(North))]
        [TestCase("RFLFFRF", 0, 0, 2, 2, typeof(East))]
        [TestCase("RFFfLffffLffLff", 0, 0, 1, 2, typeof(South))]
        [TestCase("RFMGHLFFRF", 0, 0, 2, 2, typeof(East))]
        [TestCase("RFFFFFLFFFFFLFFFFFLFFFFF", 0, 0, 0, 0, typeof(South))]
        [TestCase("FFFFFRFFFFFRFFFFFRFFFFF", 0, 0, 0, 0, typeof(West))]
        [TestCase("RFFFFFLFFFLFFRFLFFLFFFLF", 0, 0, 2, 1, typeof(East))]
        [TestCase("RFFFFFF FFFFFFF", 0, 0, 5, 0, typeof(East))]
        [TestCase("FFFFFFFFFFFFF", 0, 0, 0, 5, typeof(North))]
        [TestCase("RRFFFFFFFFFFFFF", 0, 0, 0, 0, typeof(South))]
        [TestCase("LFFFFFFFFFFFFF", 0, 0, 0, 0, typeof(West))]
        [TestCase("RFLFFRF", 2, 3, 4, 5, typeof(East))]
        public void TestRunCommands_ReturnsCorrectPositionAndDirection(
           string stringCommand, int startX, int startY, int finalX,
           int finalY, Type finalDirection)
        {
            IDirection direction = new North();
            IGrid grid = new Grid(new Coordinates(0, 0), new Coordinates(5, 5));
            IRover rover = new MarsRover(direction, new Coordinates(startX, startY), grid);
            rover.RunCommands(stringCommand);
            Assert.That(rover.CurrentPosition.XCoordinate == finalX);
            Assert.That(rover.CurrentPosition.YCoordinate == finalY);
            Assert.That(rover.CurrentDirection, Is.TypeOf(finalDirection));
        }
    }
}
