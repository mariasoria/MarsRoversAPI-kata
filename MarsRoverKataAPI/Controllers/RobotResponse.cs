namespace MarsRoverKataAPI.Controllers;

public class RobotResponse
{
    public string Direction { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public RobotResponse(string direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }
}