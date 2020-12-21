using MarsExplorer.Enums;
using System;

namespace MarsExplorer.Driver
{
    public interface ITurn
    {
        void TurnLeft();
        void TurnRight();
    }

    public interface IMove
    {
        void Move();
    }

    public interface IDriver : IMove, ITurn
    {
        IPosition CurrentPosition { get; set; }
        IPosition Drive(ICommandList commands);

    }

    public class Driver : IDriver
    {
        public IPosition CurrentPosition { get; set; }
        private readonly IPosition _startPosition;
        private readonly IPlato _plato;
        public Driver(IPlato plato, IPosition startPosition)
        {
            _plato = plato;
            _startPosition = startPosition;
            CurrentPosition = startPosition.Clone();
        }


        public IPosition Drive(ICommandList commands)
        {
            foreach (CommandType command in commands)
            {
                switch (command)
                {
                    case CommandType.Move:
                        Move();
                        break;
                    case CommandType.TurnLeft:
                        TurnLeft();
                        break;
                    case CommandType.TurnRight:
                        TurnRight();
                        break;
                }

                CheckCurrentPosition();
            }

            return CurrentPosition;
        }

        private void CheckCurrentPosition()
        {
            if (CurrentPosition.X.IsOutOfRange(_plato.XLength) || CurrentPosition.Y.IsOutOfRange(_plato.YLength))
            {
                CurrentPosition = _startPosition.Clone();//Set rover the start position for another try.
                throw new ArgumentOutOfRangeException("The rover drives out of range!!");
            }
        }

        public void Move()
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Y++;
                    break;
                case Direction.South:
                    CurrentPosition.Y--;
                    break;
                case Direction.West:
                    CurrentPosition.X--;
                    break;
                case Direction.East:
                    CurrentPosition.X++;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    CurrentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    CurrentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    CurrentPosition.Direction = Direction.North;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    CurrentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    CurrentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    CurrentPosition.Direction = Direction.North;
                    break;
            }
        }
    }
}


