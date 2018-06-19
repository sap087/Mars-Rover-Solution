using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Commands;
using MarsRover.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class CommandParserTests
    {
        [TestCase("")]
        [TestCase(null)]
        [TestCase("UK")]
        public void NullOrEmptyOrInvalidCommand__ReturnsEmptyCommandList(string stringCommands)
        {
            CommandParser commandParser = new CommandParser(stringCommands);
            IEnumerable<ICommand> commands = commandParser.BuildCommandsList().ToList();
            Assert.IsEmpty(commands);
        }

        [TestCase("L", typeof(RotateLeftCommand))]
        [TestCase("l", typeof(RotateLeftCommand))]
        [TestCase("R", typeof(RotateRightCommand))]
        [TestCase("r", typeof(RotateRightCommand))]
        [TestCase("F", typeof(MoveForwardCommand))]
        [TestCase("f", typeof(MoveForwardCommand))]
        [TestCase("rfl", typeof(RotateRightCommand), typeof(MoveForwardCommand), typeof(RotateLeftCommand))]
        [TestCase("JKRFOPLRF", typeof(RotateRightCommand), typeof(MoveForwardCommand), typeof(RotateLeftCommand), typeof(RotateRightCommand), typeof(MoveForwardCommand))]
        public void CommandParser_ReturnsCorrectCommandList(string stringCommand, params Type[] expectedCommandTypes)
        {
            CommandParser commandParser = new CommandParser(stringCommand);
            IList<ICommand> commands = commandParser.BuildCommandsList().ToList();
            IList<Type> commandTypes = commands.Select(c => c.GetType()).ToList();
            CollectionAssert.AreEqual(commandTypes, expectedCommandTypes);
        }
    }
}
