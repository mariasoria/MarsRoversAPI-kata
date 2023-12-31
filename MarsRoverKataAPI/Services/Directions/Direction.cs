using MarsRoverKataAPI.Controllers;

namespace MarsRoverKataAPI.Services.Directions
{
    public static class Facing
    {
        public enum Direction
        {
            North,
            South,
            East,
            West
        }

        public static Either<Error, Direction> GetInitialDirectionFrom(CommandsRequest request)
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

            if (request.Direction == Direction.West.ToString())
            {
                return Either<Error, Direction>.Right(Direction.West);
            }

            return Either<Error, Direction>.Left(new Error("The provided direction is not valid"));
        }
    }
}