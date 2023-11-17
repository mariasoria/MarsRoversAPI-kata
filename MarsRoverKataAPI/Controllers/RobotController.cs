using MarsRoverKataAPI.Services;
using MarsRoverKataAPI.Services.Directions;
using MarsRoverKataAPI.Services.States;
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
        var initialPosition = new Position(request.X, request.Y);
        // ToDo. Validation of the input being part of an enum?
        // ToDo. Parse from string to enum?? Replace that Direction.North
        var robot = Robot.Create(initialPosition, Services.Directions.Direction.North);
        var remoteControl = new RemoteControl(robot);
        var commands = request.Commands;

        remoteControl.Execute(commands);

        var state = robot.State;
        var direction = Direction(state);
        // var position = Position(state);
        logger.LogInformation("Todo ok, por ahora");
        return Ok(new RobotResponse(direction, 0, 0));
    }

    public static string Direction(State state)
    {
        var direction = "";
        if (state.GetType() == typeof(North))
            direction = "North";
        else if (state.GetType() == typeof(South))
            direction = "South";
        else if (state.GetType() == typeof(East))
            direction = "East";
        else if (state.GetType() == typeof(West))
            direction = "West";
        return direction;
    }
}