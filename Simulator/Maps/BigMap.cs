using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "To wide");
        }

        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall");
        }
        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(IMappable mappable, Point position)
    {
        /* if (_fields[position.X, position.Y] == null)
         {
             _fields[position.X, position.Y] = new List<IMappable>();
         }
         _fields[position.X, position.Y]?.Add(mappable);*/
        if (_fields.ContainsKey(position))
        {
            _fields[position].Add(mappable);
        }
        else
        {
            _fields.Add(position, new List<IMappable>() { mappable });
        }
    }

    public override void Remove(IMappable mappable, Point position)
    {
        //_fields[position.X, position.Y]?.Remove(mappable);
        _fields[position].Remove(mappable);
        if (_fields[position].Count == 0 | _fields[position] == null) { _fields.Remove(position); }
    }

    public override List<IMappable>? At(int x, int y)
    {
        //return _fields[x, y];
        return _fields.TryGetValue(new Point(x, y), out List<IMappable>? value) ? value : null;
    }

    public override List<IMappable>? At(Point position)
    {
        return _fields.TryGetValue(position, out List<IMappable>? value) ? value : null;
    }
}
