using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland
{
    public class MultiplyAdd : IWeightingTotaller
    {
        public int GetTotal(int[] sortCodeAccNo, int[] weightings)
        {
            int result = 0;
            for (int i = 0; i < weightings.Length; i++)
            {
                result += sortCodeAccNo[i] * weightings[i];
            }
            return result;
        }
    }
}
