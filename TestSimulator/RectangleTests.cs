using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Simulator.Point;
using Rectangle = Simulator.Rectangle;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetCoordinates()
    {
        int x1 = 1, y1 = 2, x2 = 3, y2 = 4;
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal((x1, y1, x2, y2),(rectangle.X1, rectangle.Y1, rectangle.X2, rectangle.Y2));
    }

    [Fact]
    public void Constructor_ValidPoints_ShouldSetCoordinates()
    {
        Point p1 = new Point(1, 2), p2 = new Point(3, 4);
        var rectangle = new Rectangle(p1, p2);
        Assert.Equal((p1.X, p1.Y, p2.X, p2.Y), (rectangle.X1, rectangle.Y1, rectangle.X2, rectangle.Y2));
    }

    [Fact]
    public void Constructor_WrongOrderCoordinates_ShouldSetProperCoordinates()
    {
        int x1 = 1, y1 = 6, x2 = 3, y2 = 4;
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal((x1, y2, x2, y1), (rectangle.X1, rectangle.Y1, rectangle.X2, rectangle.Y2));
    }

    [Fact]
    public void Constructor_WrongOrderPoints_ShouldSetProperCoordinates()
    {
        Point p1 = new Point(7,6), p2 = new Point(3, 4);
        var rectangle = new Rectangle(p1, p2);
        Assert.Equal((p2.X, p2.Y, p1.X, p1.Y), (rectangle.X1, rectangle.Y1, rectangle.X2, rectangle.Y2));
    }

    [Fact]
    public void Constructor_InvalidCoordinates_ShouldThrowArgumentException()
    {
        int x1 = 1, y1 = 2, x2 = 1, y2 = 4;
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Constructor_InvalidPoints_ShouldThrowArgumentException()
    {
        Point p1 = new Point(1, 4);
        Point p2 = new Point(3, 4);
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(p1, p2));
    }

    [Theory]
    [InlineData(1, 2,true)]
    [InlineData(-1, -2,false)]
    [InlineData(4, 3,true)]
    [InlineData(7, 3,false)]
    public void Contains_ShouldReturnCorrectBool(int x, int y, bool expectedBool) 
    { 
        var rectangle = new Rectangle(1,2,5,6);
        Assert.Equal(expectedBool, rectangle.Contains(new Point(x,y)));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectString()
    {
        int x1 = 1, y1 = 2, x2 = 3, y2 = 4;
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal($"({x1}, {y1}):({x2}, {y2})", rectangle.ToString());
    }
}
