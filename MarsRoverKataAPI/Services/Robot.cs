using MarsRoverKataAPI.Services.Directions;
using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services
{
    public class Robot
    {
        public State State { get; private set; }

        private Robot(State state)
        {
            State = state;
        }

        public static Robot Create(Position position, Direction direction)
        {
            if (direction == Direction.South)
            {
                return new Robot(new South(direction, position));
            }
            
            if (direction == Direction.North)
            {
                return new Robot(new North(direction, position));
            }
            
            if (direction == Direction.East)
            {
                return new Robot(new East(direction, position));
            }
            return new Robot(new West(direction, position));
        }
        
        public void TurnRight()
        {
            State = State.TurnRight();
        }

        public void TurnLeft()
        {
            State = State.TurnLeft();
        }

        public void MoveBackwards()
        {
            State = State.MoveBackwards();
        }

        public void MoveForward()
        {
            State = State.MoveForward();
        }
    }
    
}

