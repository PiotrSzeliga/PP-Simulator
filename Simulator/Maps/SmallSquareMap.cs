using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private Rectangle ssmRectangle;

    public int Size 
    {  
        get; 
    }
    
    public SmallSquareMap(int size) 
    { 
        Size = size;
        
        if (size < 5 | size > 20)
        { 
            throw new ArgumentOutOfRangeException(nameof(size),$"The size of {size} is invalid. Try a size between 5 and 20");
        }

        ssmRectangle = new Rectangle(0, 0, Size - 1, Size - 1);
    }
   
    public override bool Exist(Point p)
    {
        return ssmRectangle.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d)))
        {
            return p.Next(d);
        }
        else 
        { 
            return p;        
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
            return p;
        }
    }
}
