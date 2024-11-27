using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap(int size) : SmallMap(size, size)
{
    public override Point Next(Point p, Direction d)
    {
        return Exist(p.Next(d)) ? p.Next(d) : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return Exist(p.NextDiagonal(d)) ? p.NextDiagonal(d) : p;
    }
}
