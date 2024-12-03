using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature 
{
    public override char Symbol => 'E';
    private int singCount = 0;
    private int agility = 1;
    
    public override int Power 
    {
        get => 8 * Level + 2 * Agility;
    }
    public int Agility 
    { 
        get => agility;
        init
        {
            agility = Validator.Limiter(value, 0, 10);
        }
        
    }
    public string Sing() 
    {
        singCount++;
        if (singCount % 3 == 0 && agility < 10) { agility++; }
        return $"{Name} is singing.";
    }
    public Elf() { }
    public Elf(string name, int level=1, int agility=1)
    {
        Name = name;
        Agility = agility;
        Level = level;
    }
    public override string Greetings()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
}

    public override string Info
    {
        get { return $"{Name} [{Level}][{Agility}] ({Position})"; }
    }
}
