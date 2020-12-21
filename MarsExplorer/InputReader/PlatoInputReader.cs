using MarsExplorer.Driver;
using MarsExplorer.Enums;
using System;
using System.Linq;

namespace MarsExplorer.ConsoleInterface
{
    public class PlatoInputReader : InputReader<IPlato>
    {
        public PlatoInputReader(IFactory factory)
            : base(factory) { }

        protected override IPlato ConvertInputToObject(string input)
        {
            int[] range = input.Trim().Split(" ").Where(p => p != " " && p != string.Empty)?.Select(p => p.ToInt32()).ToArray();

            IPlato result = Factory.CreateInputObject<IPlato>();
            result.XLength = range[0];
            result.YLength = range[1];

            return result;
        }

        protected override void RequestInput()
        {
            Console.WriteLine("Please enter plato range. ex:'5 5' ");
        }
    }
}
