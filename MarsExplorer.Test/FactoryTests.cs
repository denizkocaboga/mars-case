using MarsExplorer.ConsoleInterface;
using MarsExplorer.Driver;
using MarsExplorer.InputValidator;
using Moq;
using NUnit.Framework;

namespace MarsExplorer.Test
{
    public class FactoryTests
    {
        private IFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new Factory();
        }

        #region CreateInputObject
        [Test]
        public void CreateInputObject_Should_CreatePlato_When_CallFor_IPlato()
        {
            IPlato inputObject = _factory.CreateInputObject<IPlato>();

            Assert.IsInstanceOf<Plato>(inputObject);
        }

        [Test]
        public void CreateInputObject_Should_CreatePosition_When_CallFor_IPosition()
        {
            IPosition inputObject = _factory.CreateInputObject<IPosition>();

            Assert.IsInstanceOf<Position>(inputObject);
        }

        [Test]
        public void CreateInputObject_Should_CreateCommandList_When_CallFor_ICommandList()
        {
            ICommandList inputObject = _factory.CreateInputObject<ICommandList>();

            Assert.IsInstanceOf<CommandList>(inputObject);
        }

        [Test]
        public void CreateInputObject_Should_CreateNewInstance_When_CallFor_IPlato()
        {
            IPlato inputObject1 = _factory.CreateInputObject<IPlato>();
            IPlato inputObject2 = _factory.CreateInputObject<IPlato>();

            Assert.AreNotSame(inputObject1, inputObject2);
        }

        [Test]
        public void CreateInputObject_Should_CreateNewInstance_When_CallFor_IPosition()
        {
            IPosition inputObject1 = _factory.CreateInputObject<IPosition>();
            IPosition inputObject2 = _factory.CreateInputObject<IPosition>();

            Assert.AreNotSame(inputObject1, inputObject2);
        }

        [Test]
        public void CreateInputObject_Should_CreateNewInstance_When_CallFor_ICommandList()
        {
            ICommandList inputObject1 = _factory.CreateInputObject<ICommandList>();
            ICommandList inputObject2 = _factory.CreateInputObject<ICommandList>();

            Assert.AreNotSame(inputObject1, inputObject2);
        }

        #endregion

        #region GetInputReader        
        [Test]
        public void GetInputReader_Should_CreatePlatoInputReader_When_CallFor_IPlato()
        {
            IInputReader<IPlato> inputReader = _factory.GetInputReader<IPlato>();

            Assert.IsInstanceOf<PlatoInputReader>(inputReader);
        }

        [Test]
        public void GetInputReader_Should_CreatePositionInputReader_When_CallFor_IPosition()
        {
            IInputReader<IPosition> inputReader = _factory.GetInputReader<IPosition>();

            Assert.IsInstanceOf<PositionInputReader>(inputReader);
        }

        [Test]
        public void GetInputReader_Should_CreateCommandListInputReader_When_CallFor_ICommandList()
        {
            IInputReader<ICommandList> inputReader = _factory.GetInputReader<ICommandList>();

            Assert.IsInstanceOf<CommandsInputReader>(inputReader);
        }

        [Test]
        public void GetInputReader_Should_WorkSingleton_When_CallFor_IPlato()
        {
            IInputReader<IPlato> inputReader1 = _factory.GetInputReader<IPlato>();
            IInputReader<IPlato> inputReader2 = _factory.GetInputReader<IPlato>();

            Assert.AreSame(inputReader1, inputReader2);
        }

        [Test]
        public void GetInputReader_Should_WorkSingleton_When_CallFor_IPosition()
        {
            IInputReader<IPosition> inputReader1 = _factory.GetInputReader<IPosition>();
            IInputReader<IPosition> inputReader2 = _factory.GetInputReader<IPosition>();

            Assert.AreSame(inputReader1, inputReader2);
        }

        [Test]
        public void GetInputReader_Should_WorkSingleton_When_CallFor_ICommandList()
        {
            IInputReader<ICommandList> inputReader1 = _factory.GetInputReader<ICommandList>();
            IInputReader<ICommandList> inputReader2 = _factory.GetInputReader<ICommandList>();

            Assert.AreSame(inputReader1, inputReader2);
        }

        #endregion

        #region GetInputValidator

        [Test]
        public void GetInputValidator_Should_CreatePlatoInputValidator_When_CallFor_IPlato()
        {
            IInputValidator inputValidator = _factory.GetInputValidator<IPlato>();

            Assert.IsInstanceOf<PlatoInputValidator>(inputValidator);
        }

        [Test]
        public void GetInputValidator_Should_CreatePositionInputValidator_When_CallFor_IPosition()
        {
            IInputValidator inputValidator = _factory.GetInputValidator<IPosition>();

            Assert.IsInstanceOf<PositionInputValidator>(inputValidator);
        }

        [Test]
        public void GetInputValidator_Should_CreateCommandListInputValidator_When_CallFor_ICommandList()
        {
            IInputValidator inputValidator = _factory.GetInputValidator<ICommandList>();

            Assert.IsInstanceOf<CommandListInputValidator>(inputValidator);
        }

        [Test]
        public void GetInputValidator_Should_WorkSingleton_When_CallFor_IPlato()
        {
            IInputValidator inputValidator1 = _factory.GetInputValidator<IPlato>();
            IInputValidator inputValidator2 = _factory.GetInputValidator<IPlato>();

            Assert.AreSame(inputValidator1, inputValidator2);
        }

        [Test]
        public void GetInputValidator_Should_WorkSingleton_When_CallFor_IPosition()
        {
            IInputValidator inputValidator1 = _factory.GetInputValidator<IPosition>();
            IInputValidator inputValidator2 = _factory.GetInputValidator<IPosition>();

            Assert.AreSame(inputValidator1, inputValidator2);
        }

        [Test]
        public void GetInputValidator_Should_WorkSingleton_When_CallFor_ICommandList()
        {
            IInputValidator inputValidator1 = _factory.GetInputValidator<ICommandList>();
            IInputValidator inputValidator2 = _factory.GetInputValidator<ICommandList>();

            Assert.AreSame(inputValidator1, inputValidator2);
        }


        #endregion

        #region GetInputDriver

        [Test]
        public void GetInputDriver_Should_CreateInputDriver_And_Call_StartPositionClone()
        {
            Mock<IPlato> platoMock = new Mock<IPlato>();
            Mock<IPosition> startPosition = new Mock<IPosition>();
            startPosition.Setup(p => p.X).Returns(1);
            startPosition.Setup(p => p.Y).Returns(2);
            startPosition.Setup(p => p.Direction).Returns(Enums.Direction.East);
            Mock<IPosition> currentPosition = new Mock<IPosition>();
            startPosition.Setup(p => p.Clone()).Returns(currentPosition.Object);

            IDriver driver = _factory.CreateDriver(platoMock.Object, startPosition.Object);

            Assert.AreSame(driver.CurrentPosition, currentPosition.Object);
        }

        #endregion
    }
}