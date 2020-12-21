using MarsExplorer.Enums;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsExplorer.Driver
{

    public interface IPosition : IInputObject, IEquatable<IPosition>
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
        IPosition Clone();
    }
    public class Position : IPosition
    {
        private readonly IFactory _factory;

        public Position(IFactory factory)
        {
            _factory = factory;
        }
        public Position(IFactory factory, int x, int y, Direction direction) : this(factory)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public IPosition Clone()
        {
            IPosition result = _factory.CreateInputObject<IPosition>();
            result.X = X;
            result.Y = Y;
            result.Direction = Direction;

            return result;
        }

        public bool Equals([AllowNull] IPosition other)
        {
            bool result = X == other?.X && Y == other?.Y && Direction == other?.Direction;
            return result;
        }

        public override string ToString()
        {
            return $"{X} {Y} {(char)Direction}";
        }
    }
}


