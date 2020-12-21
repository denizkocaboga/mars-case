using MarsExplorer.Driver;
using System;

namespace MarsExplorer
{

    class Program
    {
        private static readonly IFactory _factory = new Factory();

        static void Main(string[] args)
        {
            string isContinue = "Y";

            IPlato plato = _factory.GetInputReader<IPlato>().ReadInput();

            while (isContinue == "Y")
            {
                IPosition startPosition = _factory.GetInputReader<IPosition>().ReadInput();

                if (!plato.IsInRange(startPosition))
                {
                    Console.WriteLine("Start position is out of range!");
                    continue;
                }

                IDriver driver = _factory.CreateDriver(plato, startPosition);
                IPosition lastPosition = null;
                while (lastPosition == null)
                {
                    ICommandList commandList = _factory.GetInputReader<ICommandList>().ReadInput();

                    try
                    {
                        lastPosition = driver.Drive(commandList);
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine($"Rower position: {lastPosition}");

                Console.WriteLine("Do you want continue? (Y/N)");
                isContinue = Console.ReadLine().ToUpperInvariant();
            }

        }
    }





}
