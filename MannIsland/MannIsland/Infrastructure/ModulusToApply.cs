using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland
{
    public class ModulusToApply
    {
        public uint Start { get; set; }
        public uint End { get; set; }
        public int[]  Weightings { get; set; }
        public int? Ex { get; set; }

        public IWeightingTotaller WeightingTotaller { get; set; }
        public int Divisor { get; set; }

        public ModulusResult Check()
        {
            return new ModulusResult();
        }
    }
}
