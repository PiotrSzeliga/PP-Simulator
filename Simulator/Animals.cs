using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    public virtual char Symbol => 'A';
    public Map? Map { get; protected set; }
    public Point Position { get; protected set; }
    
    private string description = "Unknown";
    public required string Description
{
        get { return description; }
        init
        {
            description = Validator.Shortener(value,3,15);
        }
    }
    public uint Size { get; set; } = 3;
    public Animals(string description="Unknown",uint size = 3)
    {
        Description = description;
        Size = size; 
    }
    public void InitMapAndPosition(Map map, Point position)
    {
        if (Map != null) throw new Exception("Map has already been essigned");

        Map = map;
        Position = position;
        Map.Add(this, position);

        if (!Map.Exist(position)) throw new Exception("Point is out of map");
    }

    public virtual void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new Exception($"{this.ToString} has not been assigned a map");
        }
        else
        {
            Map.Move(this, Position, Map.Next(Position, direction));
            Position = Map.Next(Position, direction);
        }
    }

    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToString().ToUpper()}: {Info}";
    }
}
