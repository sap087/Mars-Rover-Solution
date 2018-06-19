using System.Collections.Generic;
using System.Linq;
using MarsRover.Commands;
using MarsRover.Interfaces;

namespace MarsRover
{
    /// <summary>
    /// An object which parses the input command string and builds a list 
    /// of <see cref="ICommand"/> objects to be executed by <see cref="IRover"/>
    /// </summary>
    public class CommandParser
    {
        private readonly string stringCommands;

        private IDictionary<char, ICommand> availableCommands = 
            new Dictionary<char, ICommand>()
        {
            {'R', new RotateRightCommand()},
            {'L', new RotateLeftCommand()},
            {'F', new MoveForwardCommand()}
        };

        public CommandParser(string stringCommands)
        {
            this.stringCommands = stringCommands;
        }

        public IEnumerable<ICommand> BuildCommandsList()
        {
            if (string.IsNullOrWhiteSpace(stringCommands))
            {
                return Enumerable.Empty<ICommand>();
            }

            IList<ICommand> commands = new List<ICommand>();

            foreach (char commandCharacter in stringCommands.ToUpper())
            {
                ICommand command;
                if (availableCommands.TryGetValue(commandCharacter, out command))
                {
                    commands.Add(command);
                }
            }
            return commands;
        }
    }
}
