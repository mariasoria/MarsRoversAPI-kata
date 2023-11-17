using MarsRoverKataAPI.Services;
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
        var direction = state.GetType().Name;
        var position = state.Position;
        logger.LogInformation("Todo ok, por ahora");
        return Ok(new RobotResponse(direction, position.X, position.Y));
    }
}