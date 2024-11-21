using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public static class DirectionParser
{
    public static List<Direction> Parse(string direction)
    {
       List<Direction> list = new List<Direction>();
        foreach (char c in direction.ToUpper())
       {
            switch (c)
            { 
                case 'U':
                    list.Add(Direction.Up);
                    break;

                case 'D':
                    list.Add(Direction.Down);
                    break;
                
                case 'R':
                    list.Add(Direction.Right);
                    break;
                
                case 'L':
                    list.Add(Direction.Left);
                    break;
                
                default:
                    break;
            }
       }
       return list;
    }
}