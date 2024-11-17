using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private Rectangle stmRectangle;

    public int Size
    {
        get;
    }

    public SmallTorusMap(int size)
    {
        Size = size;

        if (size < 5 | size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), $"The size of {size} is invalid. Try a size between 5 and 20");
        }

        stmRectangle = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point p)
    {
        return stmRectangle.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d)))
        {
            return p.Next(d);
        }
        else
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point(p.X, p.Y - (Size - 1));
                case Direction.Down:
                    return new Point(p.X, p.Y + (Size - 1));
                case Direction.Left:
                    return new Point(p.X + (Size - 1), p.Y);
                case Direction.Right:
                    return new Point(p.X - (Size - 1), p.Y);
                default:
                    return p;
            }
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        else
        {
            switch (d) 
            {
                case Direction.Up:
                    return Next(Next(p, Direction.Up), Direction.Right);
                case Direction.Down:
                    return Next(Next(p, Direction.Down), Direction.Left);
                case Direction.Left:
                    return Next(Next(p, Direction.Left), Direction.Up);
                case Direction.Right:
                    return Next(Next(p, Direction.Right), Direction.Down);
                default:
                    return p;
            }

        }
    }
}
