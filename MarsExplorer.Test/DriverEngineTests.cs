using MarsExplorer.Driver;
using MarsExplorer.Enums;
using NUnit.Framework;
using System;
using System.Linq;

namespace MarsExplorer.Test
{

    public class DriverEngineTests : DriverEngineTestBase
    {
        [Test]
        public void Should_WorkFine_WhenEverythinkOk_Scenario_1()
        {
            IPosition startPosition = CurrentFactory.CreateInputObject<IPosition>();
            startPosition.X = 1;
            startPosition.Y = 2;
            startPosition.Direction = Direction.North;

            IDriver driver = new Driver.Driver(CurrentPlato, startPosition);

            ICommandList commandLists = CurrentFactory.CreateInputObject<ICommandList>();
            commandLists.AddRange("LMLMLMLMM".Select(p => (CommandType)p).ToArray());


            IPosition lastPosition = driver.Drive(commandLists);

            Assert.AreEqual(lastPosition.X, 1);
            Assert.AreEqual(lastPosition.Y, 3);
            Assert.AreEqual(lastPosition.Direction, Direction.North);
        }

        [Test]
        public void Should_WorkFine_WhenEverythinkOk_Scenario_2()
        {
            IPosition startPosition = CurrentFactory.CreateInputObject<IPosition>();
            startPosition.X = 3;
            startPosition.Y = 3;
            startPosition.Direction = Direction.East;

            IDriver driver = new Driver.Driver(CurrentPlato, startPosition);

            ICommandList commandLists = CurrentFactory.CreateInputObject<ICommandList>();
            commandLists.AddRange("MMRMMRMRRM".Select(p => (CommandType)p).ToArray());


            IPosition lastPosition = driver.Drive(commandLists);

            Assert.AreEqual(lastPosition.X, 5);
            Assert.AreEqual(lastPosition.Y, 1);
            Assert.AreEqual(lastPosition.Direction, Direction.East);
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_And_ReturnStartPosition_When_RoverGetsOutOfPlato()
        {

            IPosition startPosition = CurrentFactory.CreateInputObject<IPosition>();
            startPosition.X = 3;
            startPosition.Y = 3;
            startPosition.Direction = Direction.East;

            IDriver driver = new Driver.Driver(CurrentPlato, startPosition);

            ICommandList commandLists = CurrentFactory.CreateInputObject<ICommandList>();
            commandLists.AddRange("MMMMMM".Select(p => (CommandType)p).ToArray());

            Assert.Throws<ArgumentOutOfRangeException>(() => driver.Drive(commandLists));
            Assert.IsTrue(startPosition.Equals(driver.CurrentPosition));
        }
    }
}