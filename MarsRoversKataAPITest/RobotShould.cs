using FluentAssertions;
using MarsRoverKataAPI.Services;
using MarsRoverKataAPI.Services.Directions;
using Xunit;

namespace MarsRoversKataAPITest;

// Try to parametrise test by functionality
// Move forward (facing south, facing north...)
// Move backwards (facing south, facing north...)
// Turn left (facing south, facing north...)
// turn right (facing south, facing north...)
public class RobotShould
{
    [Fact]
    public void Move_Forward()
    {
        var initialPosition = new Position(0, 0);
        var expectedPosition = new Position(0, 1);
        var robot = Robot.Create(initialPosition, Direction.North);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("f");

        var expectedState = new North(Direction.North, expectedPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }

    [Fact]
    public void Move_Backwards()
    {
        var initialPosition = new Position(0, 0);
        var expectedPosition = new Position(0, 1);
        var robot = Robot.Create(initialPosition, Direction.South);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("b");

        var expectedState = new South(Direction.South, expectedPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }

    [Fact]
    public void Rotate_Left()
    {
        var initialPosition = new Position(0, 0);
        var robot = Robot.Create(initialPosition, Direction.North);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("l");

        var expectedState = new West(Direction.West, initialPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }

    [Fact]
    public void Rotate_Right()
    {
        var initialPosition = new Position(0, 0);
        var robot = Robot.Create(initialPosition, Direction.North);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("r");

        var expectedState = new East(Direction.East, initialPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }

    [Fact]
    public void Rotate_Right_And_Move_Forward()
    {
        var initialPosition = new Position(0, 0);
        var expectedPosition = new Position(1, 0);
        var robot = Robot.Create(initialPosition, Direction.North);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("rf");

        var expectedState = new East(Direction.East, expectedPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }

    [Fact]
    public void Rotate_Left_And_Move_Backward()
    {
        var initialPosition = new Position(0, 0);
        var expectedPosition = new Position(1, 0);
        var robot = Robot.Create(initialPosition, Direction.North);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("lb");

        var expectedState = new West(Direction.West, expectedPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }


    [Fact]
    public void Rotate_Right_And_Move_Backwards_And_Rotate_Right_Move_Backwards()
    {
        var initialPosition = new Position(2, 2);
        var expectedPosition = new Position(3, 3);
        var robot = Robot.Create(initialPosition, Direction.North);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("rfrb");

        var expectedState = new South(Direction.South, expectedPosition);
        remoteControl.GetRobotState().Should().BeEquivalentTo(expectedState);
    }
}