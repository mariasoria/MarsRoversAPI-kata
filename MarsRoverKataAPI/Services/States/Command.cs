namespace MarsRoverKataAPI.Services.States
{
    public abstract class Command
    {
        protected readonly Robot Robot;

        protected Command(Robot robot)
        {
            Robot = robot;
        }
        
        public abstract void Execute();

        public static bool IsNotValid(string commands)
        {
            foreach (var command in commands)
            {
                if (command != 'f' && command != 'b' && command != 'l' && command != 'r')
                    return true;
            }

            return false;
        }
    }
}