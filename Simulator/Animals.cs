using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description
{
        get { return description; }
        init
        {
            value = value.Trim();
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            if (value.Length > 15)
            {
                value = value[..15].TrimEnd();
                value = (value.Length < 3) ? value.PadRight(3, '#') : value;
            }
            description = char.ToUpper(value[0]) + value.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;
    public Animals(string description="Unknown",uint size = 3)
    {
        Description = description;
        Size = size; 
    }
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
