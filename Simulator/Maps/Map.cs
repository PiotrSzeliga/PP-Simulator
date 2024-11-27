using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Rectangle mapRectangle;
    public int SizeX { get; init; }
    public int SizeY { get; init; }
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
    }
   
    public abstract void Add(IMappable mappable, Point position);
    public abstract void Remove(IMappable mappable, Point position);
    public void Move(IMappable mappable, Point position1, Point position2) 
    { 
        this.Add(mappable, position2);
        this.Remove(mappable, position1);
    }
    
    public abstract List<IMappable>? At(Point position);
    public abstract List<IMappable>? At(int x, int y);
    public virtual bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    }
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);
}
