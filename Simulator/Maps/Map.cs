using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class Map
{
    private readonly Rectangle mapRectangle;
    public readonly Dictionary<Point, List<IMappable>> fields;
    public int SizeX { get; init; }
    public int SizeY { get; init; }

    protected Func<Map, Point, Direction, Point>? FNext { get; set; }
    protected Func<Map, Point, Direction, Point>? FNextDiagonal { get; set; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }

        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;

        mapRectangle = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        fields = new Dictionary<Point, List<IMappable>>();
    }

    public void Add(IMappable mappable, Point position)
    {
        if (fields.ContainsKey(position))
        {
            fields[position].Add(mappable);
        }
        else
        {
            fields.Add(position, new List<IMappable>() { mappable });
        }
    }

    public void Remove(IMappable mappable, Point position)
    {
        fields[position].Remove(mappable);
        if (fields[position].Count == 0 | fields[position] == null) { fields.Remove(position); }
    }

    public void Move(IMappable mappable, Point position1, Point position2) 
    { 
        this.Add(mappable, position2);
        this.Remove(mappable, position1);
    }

    public List<IMappable>? At(Point position)
    {
        return fields.TryGetValue(position, out List<IMappable>? value) ? value : null;
    }

    public List<IMappable>? At(int x, int y)
    {
        return fields.TryGetValue(new Point(x, y), out List<IMappable>? value) ? value : null;
    }

    public virtual bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    }
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p , d) ?? p;
    public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;
}
