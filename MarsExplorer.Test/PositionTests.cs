using MarsExplorer.Driver;
using MarsExplorer.Enums;
using Moq;
using NUnit.Framework;

namespace MarsExplorer.Test
{
    public class PositionTests
    {

        [SetUp]
        public void Setup()
        {
        }

        #region Clone       

        [Test]
        public void Position_Clone_Should_CreateNewInstance_And_SetPropertiesCorrect()
        {
            IFactory factory = new Factory();
            IPosition position = factory.CreateInputObject<IPosition>();
            position.X = 1;
            position.Y = 2;
            position.Direction = Direction.North;

            IPosition newPosition = position.Clone();

            Assert.AreNotSame(position, newPosition);//Should Create New Object.
            Assert.AreEqual(position.X, newPosition.X);
            Assert.AreEqual(position.Y, newPosition.Y);
            Assert.AreEqual(position.Direction, newPosition.Direction);
        }

        [Test]
        public void Position_Clone_Should_UseFactory()
        {
            Mock<IFactory> factoryMock = new Mock<IFactory>();

            Mock<IPosition> expectedPositionMock = new Mock<IPosition>();
            factoryMock.Setup(p => p.CreateInputObject<IPosition>()).Returns(expectedPositionMock.Object);

            IPosition position = new Position(factoryMock.Object, 1, 2, Direction.North);

            IPosition actualPosition = position.Clone();

            Assert.AreSame(expectedPositionMock.Object, actualPosition);
        }

        #endregion

        #region Equal

        [Test]
        public void Position_Equal_Should_Return_True_When_EqualPositionPassed()
        {
            Mock<IFactory> factoryMock = new Mock<IFactory>();
            Mock<IPosition> otherPositionMock = new Mock<IPosition>();
            otherPositionMock.Setup(p => p.X).Returns(1);
            otherPositionMock.Setup(p => p.Y).Returns(2);
            otherPositionMock.Setup(p => p.Direction).Returns(Direction.North);

            IPosition position = new Position(factoryMock.Object, 1, 2, Direction.North);

            bool isEqual = position.Equals(otherPositionMock.Object);

            Assert.IsTrue(isEqual);
        }

        [Test]
        public void Position_Equal_Should_Return_False_When_DifferentPositionPassed()
        {
            Mock<IFactory> factoryMock = new Mock<IFactory>();
            Mock<IPosition> otherPositionMock = new Mock<IPosition>();
            otherPositionMock.Setup(p => p.X).Returns(1);
            otherPositionMock.Setup(p => p.Y).Returns(2);
            otherPositionMock.Setup(p => p.Direction).Returns(Direction.East);

            IPosition position = new Position(factoryMock.Object, 1, 2, Direction.North);

            bool isEqual = position.Equals(otherPositionMock.Object);

            Assert.False(isEqual);
        }

        #endregion

    }
}