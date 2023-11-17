namespace MarsRoverKataAPI.Controllers;

public class CommandsRequest
{
    // ToDo. Refactor this to store it in a DB so we do not have to send it in every request
    public string Direction { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string Commands { get; set; }
}