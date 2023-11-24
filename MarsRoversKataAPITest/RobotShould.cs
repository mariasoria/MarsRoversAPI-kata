using FluentAssertions;
using MarsRoverKataAPI.Services;
using MarsRoverKataAPI.Services.Directions;
using Xunit;

namespace MarsRoversKataAPITest;

public class RobotShould
{
    [Theory]
    [InlineData(Direction.North, 5, 6, "N")]
    [InlineData(Direction.South, 5, 4, "S")]
    [InlineData(Direction.East, 6, 5, "E")]
    [InlineData(Direction.West, 4, 5, "W")]
    public void Move_Forward(Direction direction, int expectedX, int expectedY, string expectedState)
    {
        var initialPosition = new Position(5, 5);
        var robot = Robot.Create(initialPosition, direction);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("f");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedState);
        remoteControl.GetRobotState().Position.X.Should().Be(expectedX);
        remoteControl.GetRobotState().Position.Y.Should().Be(expectedY);
    }

    [Theory]
    [InlineData(Direction.North, 5, 4, "N")]
    [InlineData(Direction.South, 5, 6, "S")]
    [InlineData(Direction.East, 4, 5, "E")]
    [InlineData(Direction.West, 6, 5, "W")]
    public void Move_Backwards(Direction direction, int expectedX, int expectedY, string expectedState)
    {
        var initialPosition = new Position(5, 5);
        var robot = Robot.Create(initialPosition, direction);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("b");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedState);
        remoteControl.GetRobotState().Position.X.Should().Be(expectedX);
        remoteControl.GetRobotState().Position.Y.Should().Be(expectedY);
    }

    [Theory]
    [InlineData(Direction.North, "W")]
    [InlineData(Direction.South, "E")]
    [InlineData(Direction.East, "N")]
    [InlineData(Direction.West, "S")]
    public void Rotate_Left(Direction initialDirection, string expectedDirection)
    {
        var initialPosition = new Position(0, 0);
        var robot = Robot.Create(initialPosition, initialDirection);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("l");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedDirection);
        remoteControl.GetRobotState().Position.Should().Be(initialPosition);
    }

    [Theory]
    [InlineData(Direction.North, "E")]
    [InlineData(Direction.South, "W")]
    [InlineData(Direction.East, "S")]
    [InlineData(Direction.West, "N")]
    public void Rotate_Right(Direction initialDirection, string expectedDirection)
    {
        var initialPosition = new Position(0, 0);
        var robot = Robot.Create(initialPosition, initialDirection);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("r");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedDirection);
        remoteControl.GetRobotState().Position.Should().Be(initialPosition);
    }

    [Theory]
    [InlineData(Direction.North, 6, 5, "E")]
    [InlineData(Direction.South, 4, 5, "W")]
    [InlineData(Direction.East, 5, 4, "S")]
    [InlineData(Direction.West, 5, 6, "N")]
    public void Rotate_Right_And_Move_Forward(Direction direction, int expectedX, int expectedY, string expectedState)
    {
        var initialPosition = new Position(5, 5);
        var robot = Robot.Create(initialPosition, direction);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("rf");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedState);
        remoteControl.GetRobotState().Position.X.Should().Be(expectedX);
        remoteControl.GetRobotState().Position.Y.Should().Be(expectedY);
    }

    [Theory]
    [InlineData(Direction.North, 6, 5, "W")]
    [InlineData(Direction.South, 4, 5, "E")]
    [InlineData(Direction.East, 5, 4, "N")]
    [InlineData(Direction.West, 5, 6, "S")]
    public void Rotate_Left_And_Move_Backwards(Direction direction, int expectedX, int expectedY, string expectedState)
    {
        var initialPosition = new Position(5, 5);
        var robot = Robot.Create(initialPosition, direction);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("lb");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedState);
        remoteControl.GetRobotState().Position.X.Should().Be(expectedX);
        remoteControl.GetRobotState().Position.Y.Should().Be(expectedY);
    }

    [Theory]
    [InlineData(Direction.North, 6, 6, "S")]
    [InlineData(Direction.South, 4, 4, "N")]
    [InlineData(Direction.East, 6, 4, "W")]
    [InlineData(Direction.West, 4, 6, "E")]
    public void Rotate_Right_And_Move_Forward_And_Rotate_Right_Move_Backwards(
        Direction direction, int expectedX, int expectedY, string expectedState)
    {
        var initialPosition = new Position(5, 5);
        var robot = Robot.Create(initialPosition, direction);
        var remoteControl = new RemoteControl(robot);

        remoteControl.Execute("rfrb");

        remoteControl.GetRobotState().StateName().Should().BeEquivalentTo(expectedState);
        remoteControl.GetRobotState().Position.X.Should().Be(expectedX);
        remoteControl.GetRobotState().Position.Y.Should().Be(expectedY);
    }
}