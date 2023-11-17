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

        public State MoveForward()
        {
            Position = Position.Increment();
            return new North(Position);
        }

        public State MoveBackwards()
        {
            Position = Position.Decrement();
            return new North(Position);
        }

        public State TurnRight()
        {
            return new East(Position);
        }

        public State TurnLeft()
        {
            return new West(Position);
        }
    }
}