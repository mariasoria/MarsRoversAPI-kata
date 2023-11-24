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
    [Route("move")]
    public IActionResult Move([FromBody] CommandsRequest request)
    {
        var robot = Robot.Create(request);
        if (robot.IsLeft())
        {
            return BadRequest(robot.GetLeft().Message);
        }

        var remoteControl = new RemoteControl(robot.GetRight());
        // ToDo. Validate commands
        remoteControl.Execute(request.Commands);

        logger.LogInformation("So far, so good");
        return Ok(new RobotResponse(robot.GetRight().State));
    }
}