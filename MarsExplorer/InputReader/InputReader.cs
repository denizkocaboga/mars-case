using MarsExplorer.Driver;
using MarsExplorer.Enums;
using MarsExplorer.InputValidator;
using System;

namespace MarsExplorer.ConsoleInterface
{
    public interface IInputReader { }
    public interface IInputReader<TInputObject> : IInputReader where TInputObject : IInputObject
    {
        TInputObject ReadInput();

    }

    public abstract class InputReader<TInputObject> : IInputReader<TInputObject> where TInputObject : IInputObject
    {
        public IInputValidator _validator;
        protected IFactory Factory;

        public InputReader(IFactory factory)
        {
            _validator = factory.GetInputValidator<TInputObject>();
            Factory = factory;
        }

        protected abstract void RequestInput();
        protected abstract TInputObject ConvertInputToObject(string input);

        public TInputObject ReadInput()
        {
            bool isValid = false;
            string input = string.Empty;
            while (!isValid)
            {
                RequestInput();

                input = Console.ReadLine().ToUpperInvariant();

                IValidationResult validationResult = _validator.Validate(input);

                if (!validationResult.IsValid)
                    Console.WriteLine(validationResult.Message);

                isValid = validationResult.IsValid;
            }

            TInputObject result = ConvertInputToObject(input);
            return result;
        }
    }
}
