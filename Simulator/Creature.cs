using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simulator.Maps;

namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public void InitMapAndPosition(Map map, Point position) 
    {
        if (Map != null) throw new Exception("Map has already been essigned");
        
        Map = map;
        Position = position;
        Map.Add(this, position); 
        
        if (!Map.Exist(position)) throw new Exception("Point is out of map");
    }

    private string name="Unknown";
    private int level=1;

    public abstract int Power
    {
        get;
    }
    public string Name
    {
        get { return name; }
        init
        {
           name = Validator.Shortener(value);
        }
    }
   public int Level
    {
        get { return level; }
        init
        { 
            level = Validator.Limiter(value);
        }
    }
    public abstract string Info 
    {
        get;
    }
    
    public Creature(string name = "Unknown", int level = 1)
    {
        this.name = Validator.Shortener(name, 3, 25);
        this.level = level;
    }
    public abstract string Greetings();
        //Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    
    public void Upgrade()
    {
        if (level < 10) level++;
    }
    public void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new Exception($"{this.ToString} has not been assigned a map");
        }
        else 
        {
            Point next = Map.Next(Position, direction);
            Map.Move(this, Position, next);
            Position = next;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToString().ToUpper()}: {Info}";
    }
}
