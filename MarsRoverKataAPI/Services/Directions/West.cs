using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class West : State
    {
        public Position Position { get; private set; }

        public West(Position position)
        {
            Position = position;
        }

        public State MoveForward()
        {
            Position = Position.DecrementX();
            return new West(Position);
        }

        public State MoveBackwards()
        {
            Position = Position.IncrementX();
            return new West(Position);
        }

        public State TurnRight()
        {
            return new North(Position);
        }

        public State TurnLeft()
        {
            return new South(Position);
        }
    }
}