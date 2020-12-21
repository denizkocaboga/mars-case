namespace MarsExplorer.Driver
{
    public interface IInputObject { }
    public interface IPlato : IInputObject
    {
        int XLength { get; set; }
        int YLength { get; set; }

        bool IsInRange(IPosition position);
    }
    public class Plato : IPlato
    {
        public Plato() { }
        public Plato(int lengthX, int lengthY)
        {
            XLength = lengthX;
            YLength = lengthY;
        }
        public int XLength { get; set; }
        public int YLength { get; set; }

        public bool IsInRange(IPosition position)
        {
            bool result = position.X >= 0
                && position.X <= XLength
                && position.Y >= 0
                && position.Y <= YLength;

            return result;


        }
    }


}


