namespace MarsRoverKataAPI.Services.States
{
    public class BackwardCommand : Command
    {
        public BackwardCommand(Robot robot) : base(robot)
        {
        }

        public override void Execute()
        {
            Robot.MoveBackwards();
        }
    }
}