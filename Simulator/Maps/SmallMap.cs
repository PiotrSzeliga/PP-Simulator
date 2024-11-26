using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<Creature>?[,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "To wide");
        }
        
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall");
        }
        _fields = new List<Creature>[sizeX, sizeY];    
    }

    public override void Add(Creature creature, Point position)
    {
        if (_fields[position.X, position.Y] == null)
        {
            _fields[position.X, position.Y] = new List<Creature>();
        }
        _fields[position.X, position.Y]?.Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        _fields[position.X, position.Y]?.Remove(creature);
    }

    public override List<Creature>? At(int x, int y)
    {
        return _fields[x, y];
    }
    public override List<Creature>? At(Point position)
    {
        return _fields[position.X, position.Y];
    }

}

