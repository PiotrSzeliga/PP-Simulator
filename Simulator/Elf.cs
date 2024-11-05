using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature 
{
    private int singCount=0;
    private int agility = 1;
    
    public override int Power 
    {
        get => 8 * Level + 2 * Agility;
    }
    public int Agility 
    { 
        get => agility;
        init{
            if (value > 10)
            {
                agility = 10;
            }
            else if (value < 1)
            {
                agility = 1;
            }
            else
            {
                agility = value;
            }
        }
    }
    public void Sing() 
    {
        singCount++;
        if (singCount % 3 == 0 && agility < 10) { agility++; }
        Console.WriteLine($"{Name} is singing.");
    }
    public Elf() { }
    public Elf(string name, int level=1, int agility=1)
    {
        Name = name;
        Agility = agility;
        Level = level;
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
);
}
