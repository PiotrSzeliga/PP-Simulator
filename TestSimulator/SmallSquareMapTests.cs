﻿using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int sizeX = 10, sizeY = 10;
        // Act
        var map = new SmallSquareMap(sizeX, sizeY);
        // Assert
        Assert.Equal((sizeX, sizeY), (map.SizeX, map.SizeY));
    }

    [Theory]
    [InlineData(4,4)]
    [InlineData(21,21)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException (int SizeX, int SizeY)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(SizeX, SizeY));
    }

    [Theory]
    [InlineData(3, 4, 5, 5, true)]
    [InlineData(6, 1, 5, 5, false)]
    [InlineData(19, 19, 20, 20, true)]
    [InlineData(20, 20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int SizeX, int SizeY, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(SizeX, SizeY);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(10, 8, Direction.Left, 9, 8)]
    [InlineData(19, 10, Direction.Right, 19, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20,20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(10, 19, Direction.Down, 9, 18)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(19, 10, Direction.Right, 19, 10)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
