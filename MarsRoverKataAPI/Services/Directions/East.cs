using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class East : State
    {
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }

        public East(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }

        public override State MoveForward()
        {
            Position = Position.IncrementX();
            return new East(Direction, Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.DecrementX();
            return new East(Direction, Position);
        }

        public override State TurnRight()
        {
            Direction = Direction.South;
            return new South(Direction, Position);
        }

        public override State TurnLeft()
        {
            Direction = Direction.North;
            return new North(Direction, Position);
        }
    }
}