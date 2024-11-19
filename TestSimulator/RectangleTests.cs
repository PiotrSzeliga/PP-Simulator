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
    [Theory]
    [InlineData(1, 2, 3, 4, 1, 2, 3, 4)]
    [InlineData(1, 4, 2, 3, 1, 3, 2, 4)]
    public void Constructor_ValidCoordinates_ShouldSetCoordinates(int x1, int y1, int x2, int y2, int exppectedX1, int exppectedY1, int exppectedX2, int exppectedY2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal((exppectedX1, exppectedY1, exppectedX2, exppectedY2), (rectangle.X1, rectangle.Y1, rectangle.X2, rectangle.Y2));
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 1, 2, 3, 4)]
    [InlineData(1, 4, 2, 3, 1, 3, 2, 4)]
    public void Constructor_ValidPoints_ShouldSetCoordinates(int x1, int y1, int x2, int y2, int exppectedX1, int exppectedY1, int exppectedX2, int exppectedY2)
    {
        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);
        var rectangle = new Rectangle(p1, p2);
        Assert.Equal((exppectedX1, exppectedY1, exppectedX2, exppectedY2), (rectangle.X1, rectangle.Y1, rectangle.X2, rectangle.Y2));
    }

    [Theory]
    [InlineData(1, 2, 1, 4)]
    [InlineData(1, 6, 2, 6)]
    public void Constructor_InvalidCoordinates_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(1, 2, 1, 4)]
    [InlineData(5, 6, 5, 8)]
    public void Constructor_InvalidPoints_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);
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
        int X1 = 1, Y1 = 2, X2 = 3, Y2 = 4;
        var rectangle = new Rectangle(X1, Y1, X2, Y2);
        Assert.Equal($"({X1}, {Y1}):({X2}, {Y2})", rectangle.ToString());
    }
}
