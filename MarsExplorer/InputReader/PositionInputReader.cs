using MarsExplorer.Driver;
using MarsExplorer.Enums;
using System;
using System.Linq;

namespace MarsExplorer.ConsoleInterface
{
    public class PositionInputReader : InputReader<IPosition>
    {
        public PositionInputReader(IFactory factory)
            : base(factory) { }
        protected override IPosition ConvertInputToObject(string input)
        {
            string[] positions = input?.Trim()?.Split(" ").Where(p => p != " " && p != string.Empty)?.ToArray();
            IPosition position = Factory.CreateInputObject<IPosition>();
            position.X = positions[0].ToInt32();
            position.Y = positions[1].ToInt32();
            position.Direction = (Direction)positions[2][0];//positions[2] is string. first element of string is char.

            return position;
        }

        protected override void RequestInput()
        {
            Console.WriteLine("Please enter start position of rover. ex:'1 2 N'");
        }
    }
}
