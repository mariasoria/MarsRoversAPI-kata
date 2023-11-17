using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class North : State
    {
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }

        public North(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }

        public override State MoveForward()
        {
            Position = Position.Increment();
            return new North(Direction, Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.Decrement();
            return new North(Direction, Position);
        }

        public override State TurnRight()
        {
            Direction = Direction.East;
            return new East(Direction, Position);
        }

        public override State TurnLeft()
        {
            Direction = Direction.West;
            return new West(Direction, Position);
        }
    }
    
}