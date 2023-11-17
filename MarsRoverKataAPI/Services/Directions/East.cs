using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class East : State
    {
        public Position Position { get; private set; }

        public East(Position position)
        {
            Position = position;
        }

        public State MoveForward()
        {
            Position = Position.IncrementX();
            return new East(Position);
        }

        public State MoveBackwards()
        {
            Position = Position.DecrementX();
            return new East(Position);
        }

        public State TurnRight()
        {
            return new South(Position);
        }

        public State TurnLeft()
        {
            return new North(Position);
        }
    }
}