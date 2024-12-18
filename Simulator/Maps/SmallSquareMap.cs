﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap: SmallMap
{
    public SmallSquareMap(int size) : base(size, size) 
    { 
        FNext = MoveRules.WallNext;
        FNextDiagonal = MoveRules.WallNextDiagonal;
    }
}
