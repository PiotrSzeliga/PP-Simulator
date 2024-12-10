using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigBounceMap(int SizeX, int SizeY) : BigMap(SizeX, SizeY)
{
    public override Point Next(Point p, Direction d)
    {
        return Exist(p.Next(d))
            ? p.Next(d)
            : p.Next(DirectionParser.OppositeDirection(d));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (!Exist(p.NextDiagonal(d)) & !Exist(p.NextDiagonal(DirectionParser.OppositeDirection(d)))) { return p; }
        else if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }
        else { return p.NextDiagonal(DirectionParser.OppositeDirection(d)); }
    }
}