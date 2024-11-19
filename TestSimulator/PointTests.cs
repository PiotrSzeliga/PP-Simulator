using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_Coordinates_ShouldSetCoordinates()
    {
        int x = 1, y = 2;
        var point = new Point(x, y);
        Assert.Equal((x, y), (point.X,point.Y));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectString() 
    {
        int x = 1, y = 2;
        var point = new Point(x, y);
        Assert.Equal($"({x}, {y})",point.ToString());
    }

    [Theory]
    [InlineData(10, -10, Direction.Up, 10, -9)]
    [InlineData(-5, 5, Direction.Down, -5, 4)]
    [InlineData(-10, 10, Direction.Left, -11, 10)]
    [InlineData(5, -5, Direction.Right, 6, -5)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(new Point(expectedX,expectedY), nextPoint);
    }

    [Theory]
    [InlineData(10, -10, Direction.Up, 11, -9)]
    [InlineData(-5, 5, Direction.Down, -6, 4)]
    [InlineData(-10, 10, Direction.Left, -11, 11)]
    [InlineData(5, -5, Direction.Right, 6, -6)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
