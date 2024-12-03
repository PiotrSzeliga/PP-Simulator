using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; }
    public override char Symbol => CanFly ? 'B' : 'b';


    public override string Info
    {
        get { return $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>"; }
    }

    public override void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new Exception($"{this.ToString} has not been assigned a map");
        }
        else if (CanFly)
        {
            Map.Move(this, Position, Map.Next(Map.Next(Position, direction), direction));
            Position = Map.Next(Map.Next(Position, direction), direction);
        }
        else 
        {
            Map.Move(this, Position, Map.NextDiagonal(Position, direction));
            Position = Map.NextDiagonal(Position, direction);
        }
    }
}

