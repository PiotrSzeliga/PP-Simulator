using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Creature
{
    public string Name { get; set; } = "Istota";
    public int Level { get; set; } = 1;
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
    public Creature(string name, int level)
    {
        this.Name = name;
        this.Level = level; 
    }
    public void SayHi() {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

}
