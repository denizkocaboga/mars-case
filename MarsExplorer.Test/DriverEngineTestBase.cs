using MarsExplorer.Driver;
using Moq;
using NUnit.Framework;

namespace MarsExplorer.Test
{
    public class DriverEngineTestBase
    {
        protected IFactory CurrentFactory;
        protected IPlato CurrentPlato;

        [SetUp]
        public void Setup()
        {
            Mock<IFactory> factory = new Mock<IFactory>();
            CurrentFactory = factory.Object;

            Mock<IPlato> plato = new Mock<IPlato>();
            plato.Setup(p => p.XLength).Returns(5);
            plato.Setup(p => p.YLength).Returns(5);
            CurrentPlato = plato.Object;

            //Plato = new Plato(5, 5);

            factory.Setup(p => p.CreateInputObject<IPlato>()).Returns(CurrentPlato);
            factory.Setup(p => p.CreateInputObject<IPosition>()).Returns(new Position(factory.Object));
            factory.Setup(p => p.CreateInputObject<ICommandList>()).Returns(new CommandList());

            //factory.Setup(p => p.CreateDriver(CurrentPlato, It.IsAny<IPosition>())).Returns(new Driver.Driver(CurrentPlato, It.IsAny<IPosition>()));

        }
    }
}