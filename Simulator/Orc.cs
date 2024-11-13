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
            rage = Validator.Limiter(value, 0, 10);
        }
    }
    public string Hunt()
    {
        huntCount++;
        if (huntCount % 3 == 0 && rage < 10) { rage++; }
        return ($"{Name} is hunting.");
    }
    public Orc() { }
    public Orc(string name, int level=1, int rage =1) 
    {
        Name = name;
        Rage = rage; 
        Level = level;
    }
    public override string Greetings()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
}

    public override string Info
    {
        get { return $"{Name} [{Level}][{Rage}]"; }
    }
}