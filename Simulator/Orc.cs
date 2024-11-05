using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int huntCount = 0;
    private int rage = 1;

    public override int Power
    {
        get => 7 * Level + 3 * Rage;
    }
    public int Rage
    {
        get => rage;
        init
        {
            if (value > 10)
            {
                rage = 10;
            }
            else if (value < 1)
            {
                rage = 1;
            }
            else
            {
                rage = value;
            }
        }
    }
    public void Hunt()
    {
        huntCount++;
        if (huntCount % 3 == 0 && rage < 10) { rage++; }
        Console.WriteLine($"{Name} is hunting.");
    }
    public Orc(){}
    public Orc(string name, int level=1, int rage =1) 
    {
        Name = name;
        Rage = rage; 
        Level = level;
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
);
}