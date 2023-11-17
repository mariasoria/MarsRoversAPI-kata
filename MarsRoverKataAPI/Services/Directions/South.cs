using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class South : State
    {
        public Position Position { get; private set; }

        public South(Position position)
        {
            Position = position;
        }

        public override State MoveForward()
        {
            Position = Position.Decrement();
            return new South(Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.Increment();
            return new South(Position);
        }

        public override State TurnRight()
        {
            return new West(Position);
        }

        public override State TurnLeft()
        {
            return new East(Position);
        }
    }
}