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
        // ToDo ??? Make this an interface and build 3 versions
        public object ModVal { get; set; }
        public int[] SortCodeWeightings { get; set; }
        public int[] AccountNoWeightings { get; set; }
        public int? Ex { get; set; }
    }
}
