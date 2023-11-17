using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class North : State
    {
        public Position Position { get; private set; }

        public North(Position position)
        {
            Position = position;
        }

        public override State MoveForward()
        {
            Position = Position.Increment();
            return new North(Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.Decrement();
            return new North(Position);
        }

        public override State TurnRight()
        {
            return new East(Position);
        }

        public override State TurnLeft()
        {
            return new West(Position);
        }
    }
    
}