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
            description = Validator.Shortener(value,3,15);
        }
    }
    public uint Size { get; set; } = 3;
    public Animals(string description="Unknown",uint size = 3)
    {
        Description = description;
        Size = size; 
    }
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
    public override string ToString()
    {
        return $"{this.GetType().Name.ToString().ToUpper()}: {Info}";
    }
}
