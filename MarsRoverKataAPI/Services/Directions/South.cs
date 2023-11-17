using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class South : State
    {
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }

        public South(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }

        public override State MoveForward()
        {
            Position = Position.Decrement();
            return new South(Direction, Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.Increment();
            return new South(Direction, Position);
        }

        public override State TurnRight()
        {
            Direction = Direction.West;
            return new West(Direction, Position);
        }

        public override State TurnLeft()
        {
            Direction = Direction.East;
            return new East(Direction, Position);
        }
    }
}