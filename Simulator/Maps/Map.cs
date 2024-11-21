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
    public int SizeX { get; }
    public int SizeY { get; }
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
    //public void Add(Creature creature, Point position) { }
    //public void Remove(Creature creature, Point position) { }
    //public void Move(Creature creature, Point position, Direction direction) 
    //{ 
        //Add(creature, position);
        //Remove(creature, position);
    //}
    //public abstract List<Creature>? At(int x, int y);
    public virtual bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    }
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);
}
