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

        public override State MoveForward()
        {
            Position = Position.DecrementX();
            return new West(Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.IncrementX();
            return new West(Position);
        }

        public override State TurnRight()
        {
            return new North(Position);
        }

        public override State TurnLeft()
        {
            return new South(Position);
        }
    }
}