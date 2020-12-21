using MarsExplorer.ConsoleInterface;
using MarsExplorer.Driver;
using MarsExplorer.Enums;
using MarsExplorer.InputValidator;
using System;
using System.Collections.Generic;

namespace MarsExplorer
{
    public interface IFactory
    {
        TInputObject CreateInputObject<TInputObject>() where TInputObject : IInputObject;

        IInputValidator GetInputValidator<TInputObject>() where TInputObject : IInputObject;

        IInputReader<TInputObject> GetInputReader<TInputObject>() where TInputObject : IInputObject;
        IDriver CreateDriver(IPlato plato, IPosition startPosition);
    }

    public class Factory : IFactory
    {
        private readonly Dictionary<Type, IInputValidator> _validators;
        private readonly Dictionary<Type, IInputReader> _readers;

        public Factory()
        {
            _validators = new Dictionary<Type, IInputValidator>();
            _readers = new Dictionary<Type, IInputReader>();
        }

        public IDriver CreateDriver(IPlato plato, IPosition startPosition)
        {
            Driver.Driver result = new Driver.Driver(plato, startPosition);
            return result;
        }

        public TInputObject CreateInputObject<TInputObject>() where TInputObject : IInputObject
        {
            Type inputObjectType = typeof(TInputObject);
            IInputObject result;

            if (inputObjectType == typeof(IPlato))
                result = new Plato();
            else if (inputObjectType == typeof(IPosition))
                result = new Position(this);
            else if (inputObjectType == typeof(ICommandList))
                result = new CommandList();
            else
                throw new ArgumentOutOfRangeException();

            return (TInputObject)result;

        }

        public IInputReader<TInputObject> GetInputReader<TInputObject>() where TInputObject : IInputObject
        {
            IInputReader<TInputObject> result;
            Type inputObjectType = typeof(TInputObject);

            if (_readers.ContainsKey(inputObjectType))
                result = (IInputReader<TInputObject>)_readers[inputObjectType];
            else
            {

                if (inputObjectType == typeof(IPlato))
                    result = (IInputReader<TInputObject>)new PlatoInputReader(this);
                else if (inputObjectType == typeof(IPosition))
                    result = (IInputReader<TInputObject>)new PositionInputReader(this);
                else if (inputObjectType == typeof(ICommandList))
                    result = (IInputReader<TInputObject>)new CommandsInputReader(this);
                else
                    throw new ArgumentOutOfRangeException();

                _readers.Add(inputObjectType, result);
            }

            return result;
        }

        public IInputValidator GetInputValidator<TInputObject>() where TInputObject : IInputObject
        {
            IInputValidator result;
            Type inputObjectType = typeof(TInputObject);

            if (_validators.ContainsKey(inputObjectType))
                result = _validators[inputObjectType];
            else
            {
                if (inputObjectType == typeof(IPlato))
                    result = new PlatoInputValidator();
                else if (inputObjectType == typeof(IPosition))
                    result = new PositionInputValidator();
                else if (inputObjectType == typeof(ICommandList))
                    result = new CommandListInputValidator();
                else
                    throw new ArgumentOutOfRangeException();

                _validators.Add(inputObjectType, result);
            }

            return result;
        }
    }





}
