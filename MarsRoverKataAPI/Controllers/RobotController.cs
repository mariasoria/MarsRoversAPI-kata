using MarsRoverKataAPI.Services;
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
    [Route("move")]
    public IActionResult Move([FromBody] CommandsRequest request)
    {
        var robot = Robot.Create(request);
        if (robot.HasError() || Command.IsNotValid(request.Commands))
        {
            return BadRequest("Some of the provided information is not valid");
        }

        var remoteControl = new RemoteControl(robot.Get());
        remoteControl.Execute(request.Commands);

        logger.LogInformation("So far, so good");
        return Ok(new RobotResponse(robot.Get().State));
    }
}