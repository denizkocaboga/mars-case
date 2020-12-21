using MarsExplorer.Driver;
using Moq;
using NUnit.Framework;

namespace MarsExplorer.Test
{
    public class PlatoTests
    {
        private IPlato _plato;
        private Mock<IPosition> _positionMock;

        [SetUp]
        public void Setup()
        {
            _plato = new Factory().CreateInputObject<IPlato>();
            _plato.XLength = 5;
            _plato.YLength = 5;

            _positionMock = new Mock<IPosition>();
        }

        [Test]
        public void Plato_IsInRange_Should_Return_True_When_Input_Is_InRange()
        {
            _positionMock.Setup(p => p.X).Returns(1);
            _positionMock.Setup(p => p.Y).Returns(2);

            bool isInRange = _plato.IsInRange(_positionMock.Object);

            Assert.IsTrue(isInRange);
        }

        [Test]
        public void Plato_IsInRange_Should_Return_False_When_Input_Is_InNotRange()
        {
            _positionMock.Setup(p => p.X).Returns(6);
            _positionMock.Setup(p => p.Y).Returns(2);

            bool isInRange = _plato.IsInRange(_positionMock.Object);

            Assert.False(isInRange);
        }
    }
}