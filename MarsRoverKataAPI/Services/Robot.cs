using MarsRoverKataAPI.Controllers;
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
            return direction switch
            {
                Direction.South => new Robot(new South(position)),
                Direction.North => new Robot(new North(position)),
                Direction.East => new Robot(new East(position)),
                _ => new Robot(new West(position))
            };
        }

        public static Either<Error, Robot> Create(CommandsRequest request)
        {
            var initialPosition = Position.Create(request.X, request.Y);
            var initialDirection = GetInitialDirectionFrom(request);
            if (initialPosition.IsLeft() || initialDirection.IsLeft())
            {
                return Either<Error, Robot>.Left(new Error("The provided information is not valid"));
            }

            return CreateRobotLocatedIn(initialPosition, initialDirection);
        }

        private static Either<Error, Robot> CreateRobotLocatedIn(Either<Error, Position> initialPosition,
            Either<Error, Direction> initialDirection)
        {
            if (initialDirection.GetRight() == Direction.South)
            {
                return Either<Error, Robot>.Right(new Robot(new South(initialPosition.GetRight())));
            }

            if (initialDirection.GetRight() == Direction.North)
            {
                return Either<Error, Robot>.Right(new Robot(new North(initialPosition.GetRight())));
            }

            if (initialDirection.GetRight() == Direction.East)
            {
                return Either<Error, Robot>.Right(new Robot(new East(initialPosition.GetRight())));
            }
            if (initialDirection.GetRight() == Direction.West)
            {
                return Either<Error, Robot>.Right(new Robot(new West(initialPosition.GetRight())));
            }
            return Either<Error, Robot>.Left(new Error("The provided direction is not valid"));
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

        // ToDo. Move this to Direction??
        private static Either<Error, Direction> GetInitialDirectionFrom(CommandsRequest request)
        {
            if (request.Direction == Direction.North.ToString())
            {
                return Either<Error, Direction>.Right(Direction.North);
            }

            if (request.Direction == Direction.South.ToString())
            {
                return Either<Error, Direction>.Right(Direction.South);
            }

            if (request.Direction == Direction.East.ToString())
            {
                return Either<Error, Direction>.Right(Direction.East);
            }

            return Either<Error, Direction>.Right(Direction.West);
        }
    }
}