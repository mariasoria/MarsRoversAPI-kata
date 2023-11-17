using MarsRoverKataAPI.Services.Directions;

namespace MarsRoverKataAPI.Services.States
{
    public abstract class State
    {
        public abstract State MoveForward();
        public abstract State MoveBackwards();
        public abstract State TurnRight();
        public abstract State TurnLeft();
    }
}