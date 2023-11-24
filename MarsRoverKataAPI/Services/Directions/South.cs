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

        public State MoveForward()
        {
            Position = Position.Decrement();
            return new South(Position);
        }

        public State MoveBackwards()
        {
            Position = Position.Increment();
            return new South(Position);
        }

        public State TurnRight()
        {
            return new West(Position);
        }

        public State TurnLeft()
        {
            return new East(Position);
        }

        public string StateName()
        {
            return "S";
        }
    }
}