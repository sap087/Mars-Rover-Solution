using System;
using MarsRover.Direction;
using MarsRover.Interfaces;

namespace MarsRover
{
    class Program
    {
        // Please see the MarsRoverTests.TestRunCommands_ReturnsCorrectPositionAndDirection
        // for various test inputs and their expected result.
        static void Main(string[] args)
        {
            string stringCommands = string.Join(string.Empty, args);
            if (string.IsNullOrEmpty(stringCommands))
            {
                Console.Write("Enter Commands for Rover: ");
                stringCommands = Console.ReadLine();
            }
            IDirection direction = new North();
            Coordinates startCoordinates = new Coordinates(0, 0);
            IGrid grid = new Grid(startCoordinates, new Coordinates(5,5));
            IRover marsRover = new MarsRover(direction, startCoordinates, grid);
            marsRover.RunCommands(stringCommands);
            Console.WriteLine(
                "Position of Rover after executing the commands : {0}", marsRover);
            Console.ReadLine();
        }
    }
}
