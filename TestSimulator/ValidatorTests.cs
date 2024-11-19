using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(-5, 1, 10, 1)]
    [InlineData(50, 1, 10, 10)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expectedValue) 
    { 
        Assert.Equal(expectedValue, Validator.Limiter(value,min,max));
    }

    [Theory]
    [InlineData("   Shrek    ", "Shrek")]
    [InlineData("  ","###")]
    [InlineData("  donkey ","Donkey")]
    [InlineData("Puss in Boots – a clever and brave cat.", "Puss in Boots – a clever")]
    [InlineData("a                            troll name", "A##")]
    [InlineData("   Cats ","Cats")]
    [InlineData("Mice           are great", "Mice           are great")]
    public void Shortener_ShouldReturnCorrectString(string name, string expectedName) 
    { 
        Assert.Equal(expectedName, Validator.Shortener(name));
    }
}
