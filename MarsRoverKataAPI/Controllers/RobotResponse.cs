using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Controllers;

public class RobotResponse
{
    public string Direction { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public RobotResponse(State state)
    {
        Direction = state.GetType().Name;
        X = state.Position.X;
        Y = state.Position.Y;
    }
}