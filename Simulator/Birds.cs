using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

internal class Birds : Animals
{
    public bool CanFly { get; } = true;
    public override string Info
    {
        get { return $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>"; }
    }
}
