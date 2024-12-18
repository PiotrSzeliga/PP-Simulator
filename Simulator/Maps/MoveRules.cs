using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

static internal class MoveRules
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        return m.Exist(p.Next(d)) ? p.Next(d) : p;
    }
    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        return m.Exist(p.NextDiagonal(d)) ? p.NextDiagonal(d) : p;
    }
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
