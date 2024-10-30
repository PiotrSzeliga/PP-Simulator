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
    private string name="Unknown";
    private int level=1;
   
    public string Name
    {
        get { return name; }
        init
        {
            value = value.Trim();
            if (value.Length < 3)
            {
                name = value.PadRight(3, '#');
            }
            if (value.Length > 25)
            {
                value = value[..25].TrimEnd();
                value = (value.Length < 3) ? value.PadRight(3, '#') : value;
            }   
            name = char.ToUpper(name[0])+name.Substring(1);
        }
    }
   public int Level
    {
        get { return level; }
        init
        { 
            if (value > 10) 
            {
                level = 10;
            }
            else if (value < 1)
            {
                level = 1;
            }
            else
            {
                level = value;
            }
        }
    }
    public string Info
    {
        get { return $"{name} [{level}]"; }
    }
    public Creature(string name = "Unknown", int level = 1)
    {
        name = name.Trim();
        if (name.Length < 3)
        {
            name = name.PadRight(3, '#');
        }
        if (name.Length > 25)
        {
            name = name[..25].TrimEnd();
            name = (name.Length < 3) ? name.PadRight(3, '#') : name;
        }
        this.name = char.ToUpper(name[0]) + name.Substring(1);

    }
    public void SayHi() {
        Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    }
    public void Upgrade()
    {
        if ( level < 10 )
        { 
        level++;
        }  
    }
    public void Go(Direction directions)   
    {
        Console.WriteLine($"{name} goes {directions.ToString().ToLower()}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions) 
        { 
            Go(direction);
        }
    }
    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
}
