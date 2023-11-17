namespace MarsRoverKataAPI.Services.States
{
    public class LeftCommand : Command
    {
        public LeftCommand(Robot robot) : base(robot)
        {
        }

        public override void Execute()
        {
            Robot.TurnLeft();
        }
    }
}