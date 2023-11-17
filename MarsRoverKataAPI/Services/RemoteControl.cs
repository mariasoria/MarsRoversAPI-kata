using MarsRoverKataAPI.Services.States;

namespace MarsRoverKataAPI.Services
{
    public class RemoteControl
    {
        private readonly Robot robot;

        public RemoteControl(Robot robot)
        {
            this.robot = robot;
        }

        public void Execute(string commands)
        {
            var commandLetter = commands.ToCharArray();
            foreach (var c in commandLetter)
            {
                var command = (Command)(c.ToString() switch
                {
                    "f" => new ForwardCommand(robot),
                    "b" => new BackwardCommand(robot),
                    "l" => new LeftCommand(robot),
                    "r" => new RightCommand(robot),
                    _ => throw new ArgumentException($"Unknown command {c.ToString()}")
                });
                command.Execute();
            }
        }

        public State GetRobotState()
        {
            return robot.State;
        }
    }
}