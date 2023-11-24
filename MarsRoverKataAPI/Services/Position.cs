namespace MarsRoverKataAPI.Services
{
    public class Position
    {
        public readonly int X;
        public readonly int Y;

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

        public static Either<Error, Position> Create(int X, int Y)
        {
            if(X < 0 || Y < 0)
            {
                return Either<Error, Position>.Left(new Error("X and Y must be positive"));
            }
            if(X > 10 || Y > 10)
            {
                return Either<Error, Position>.Left(new Error("X and Y must be less than 10"));
            }

            return Either<Error, Position>.Right(new Position(X, Y));
        }
    }
}