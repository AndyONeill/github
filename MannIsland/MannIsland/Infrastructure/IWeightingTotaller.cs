﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland
{
    public interface IWeightingTotaller
    {
        Int32 GetTotal(int[] sortCodeAccNo, int[] weightings);
    }
}