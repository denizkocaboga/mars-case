using MarsExplorer.Driver;
using MarsExplorer.Enums;
using System;
using System.Linq;

namespace MarsExplorer.ConsoleInterface
{
    public class CommandsInputReader : InputReader<ICommandList>
    {
        public CommandsInputReader(IFactory factory) : base(factory) { }

        protected override ICommandList ConvertInputToObject(string input)
        {
            CommandList commandList = (CommandList)Factory.CreateInputObject<ICommandList>();

            CommandType[] commands = input?.Trim()?
                                           .Replace(" ", string.Empty)?
                                           .Select(p => (CommandType)p)
                                           .ToArray();
            commandList.AddRange(commands);

            return commandList;
        }

        protected override void RequestInput()
        {
            Console.WriteLine("Please enter driver commands. ex:'LMLMLMLMM'");

        }
    }
}
