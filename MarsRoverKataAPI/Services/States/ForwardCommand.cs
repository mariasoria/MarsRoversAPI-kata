namespace MarsRoverKataAPI.Services.States
{
    public class ForwardCommand : Command
    {
        public ForwardCommand(Robot robot) : base(robot)
        {
        }

        public override void Execute()
        {
            Robot.MoveForward();
        }
    }
}