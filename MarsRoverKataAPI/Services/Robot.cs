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

        public static Robot Create(Position position, Facing.Direction direction)
        {
            return direction switch
            {
                Facing.Direction.South => new Robot(new South(position)),
                Facing.Direction.North => new Robot(new North(position)),
                Facing.Direction.East => new Robot(new East(position)),
                _ => new Robot(new West(position))
            };
        }

        public static Either<Error, Robot> Create(CommandsRequest request)
        {
            var initialPosition = Position.Create(request.X, request.Y);
            var initialDirection = Facing.GetInitialDirectionFrom(request);
            if (initialPosition.HasError() || initialDirection.HasError())
            {
                return Either<Error, Robot>.Left(new Error("The provided information is not valid"));
            }

            return CreateRobotLocatedIn(initialPosition, initialDirection);
        }

        private static Either<Error, Robot> CreateRobotLocatedIn(Either<Error, Position> initialPosition,
            Either<Error, Facing.Direction> initialDirection)
        {
            if (initialDirection.Get() == Facing.Direction.South)
            {
                return Either<Error, Robot>.Right(new Robot(new South(initialPosition.Get())));
            }

            if (initialDirection.Get() == Facing.Direction.North)
            {
                return Either<Error, Robot>.Right(new Robot(new North(initialPosition.Get())));
            }

            if (initialDirection.Get() == Facing.Direction.East)
            {
                return Either<Error, Robot>.Right(new Robot(new East(initialPosition.Get())));
            }
            if (initialDirection.Get() == Facing.Direction.West)
            {
                return Either<Error, Robot>.Right(new Robot(new West(initialPosition.Get())));
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

    }
}