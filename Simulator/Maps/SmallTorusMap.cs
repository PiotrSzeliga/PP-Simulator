using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap(int SizeX, int SizeY) : SmallMap(SizeX, SizeY)
{
    public override Point Next(Point p, Direction d)
    {
        return Exist(p.Next(d))
            ? p.Next(d)
            : d switch
            {
                Direction.Up => new Point(p.X, p.Y - (SizeY - 1)),
                Direction.Down => new Point(p.X, p.Y + (SizeY - 1)),
                Direction.Left => new Point(p.X + (SizeX - 1), p.Y),
                Direction.Right => new Point(p.X - (SizeX - 1), p.Y),
                _ => p,
            };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return Exist(p.NextDiagonal(d))
            ? p.NextDiagonal(d)
            : d switch
            {
                Direction.Up => Next(Next(p, Direction.Up), Direction.Right),
                Direction.Down => Next(Next(p, Direction.Down), Direction.Left),
                Direction.Left => Next(Next(p, Direction.Left), Direction.Up),
                Direction.Right => Next(Next(p, Direction.Right), Direction.Down),
                _ => p,
            };
    }
}
