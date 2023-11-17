namespace MarsRoverKataAPI.Services.States
{
    public interface State
    {
        public Position Position { get; }

        public State MoveForward();
        public State MoveBackwards();
        public State TurnRight();
        public State TurnLeft();
    }
}