using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland
{
    public class MultiplyAddByCharacter : IWeightingTotaller
    {
        public int GetTotal(List<int> sortCodeAccNo, int[] weightings)
        {
            int result = 0;
            for (int i = 0; i < weightings.Length; i++)
            {
                string nums = (sortCodeAccNo[i] * weightings[i]).ToString();
                foreach (char c in nums)
                {
                    result += (int)Char.GetNumericValue(c);
                }
            }
            return result;
        }
    }
}
