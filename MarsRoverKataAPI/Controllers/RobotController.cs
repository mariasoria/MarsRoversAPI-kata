using MarsRoverKataAPI.Services;
using MarsRoverKataAPI.Services.Directions;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverKataAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotController : ControllerBase
{
    private readonly ILogger<RobotController> logger;

    public RobotController(ILogger<RobotController> logger)
    {
        this.logger = logger;
    }

    [HttpPost]
    public IActionResult Move([FromBody] CommandsRequest request)
    {
        // ToDo. Validation of the inputs
        var initialPosition = new Position(request.X, request.Y);
        var initialDirection = GetInitialDirectionFrom(request);
        var robot = Robot.Create(initialPosition, initialDirection);
        var remoteControl = new RemoteControl(robot);
        var commands = request.Commands;

        remoteControl.Execute(commands);

        var state = robot.State;
        var direction = state.GetType().Name;
        var position = state.Position;
        logger.LogInformation("Todo ok, por ahora");
        return Ok(new RobotResponse(direction, position.X, position.Y));
    }

    private static Direction GetInitialDirectionFrom(CommandsRequest request)
    {
        if(request.Direction == Direction.North.ToString())
        {
            return Direction.North;
        }
        if(request.Direction == Direction.South.ToString())
        {
            return Direction.South;
        }
        if(request.Direction == Direction.East.ToString())
        {
            return Direction.East;
        }
        return Direction.West;
    }
}