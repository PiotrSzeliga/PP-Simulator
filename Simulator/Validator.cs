using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Validator
{
    public static int Limiter(int value, int min=1, int max=10) 
    {
        if (value > max)
        {
            return max;
        }
        else if (value < min)
        {
            return min;
        }
        else
        {
            return value;
        }
    }

    public static string Shortener(string value, int min = 3, int max = 25, char placeholder = '#')
    {
        value = value.Trim();
        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }
        if (value.Length > max)
        {
            value = value[..max].TrimEnd();
            value = (value.Length < min) ? value.PadRight(min, placeholder) : value;
        }
        return char.ToUpper(value[0]) + value.Substring(1);
    }
}
