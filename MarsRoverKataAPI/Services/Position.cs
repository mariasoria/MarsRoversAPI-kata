namespace MarsRoverKataAPI.Services
{
    public class Position
    {
        private int X { get; }
        private int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public Position Increment()
        {
            return new Position(X, Y + 1);
        }

        public Position Decrement()
        {
            return new Position(X, Y - 1);
        }

        public Position IncrementX()
        {
            return new Position(X + 1, Y);
        }

        public Position DecrementX()
        {
            return new Position(X - 1, Y);
        }
    }
}