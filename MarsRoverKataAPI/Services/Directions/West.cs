using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services.Directions
{
    public class West : State
    {
        public Direction Direction { get; private set; }
        public Position Position { get; private set; }

        public West(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }

        public override State MoveForward()
        {
            Position = Position.DecrementX();
            return new West(Direction, Position);
        }

        public override State MoveBackwards()
        {
            Position = Position.IncrementX();
            return new West(Direction, Position);
        }

        public override State TurnRight()
        {
            Direction = Direction.North;
            return new North(Direction, Position);
        }

        public override State TurnLeft()
        {
            Direction = Direction.South;
            return new South(Direction, Position);
        }
    }
}