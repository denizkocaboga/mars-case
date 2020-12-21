using MarsExplorer.ConsoleInterface;
using MarsExplorer.Driver;
using NUnit.Framework;

namespace MarsExplorer.Test
{
    //ToDo: In here console object breaks the unit test. Console should use with wrapping.
    //ToDo: Console objesi nedeniyle mock yapılamıyor. Console objesi sarmalanıp kullanılırsa mock yapılabilir. Vakit kalırsa yapacağım.
    public class InputReaderTests
    {
        private IFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new Factory();
        }

        [Test]
        public void PlatoInputReader__Should_ShouldReturnPlato()
        {
            IInputReader<IPlato> platoReader = _factory.GetInputReader<IPlato>();
            

            //platoReader.ReadInput();

        }
    }
}