using System;
using Xunit;
using MannIsland.Services;
using MannIsland;

namespace Tests
{
    public class ModulusChecks
    {
        [Fact]
        public void DoubleExampleAdditionMatches()
        {
            MultiplyAddByCharacter mac = new MultiplyAddByCharacter();
            int[] sortCodeAccNo = new int[] {4, 9, 9, 2, 7, 3, 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] weightings = new int[] {2,1,2,1,2,1,2,1,2,1,2,1,2,1 };
            int total = mac.GetTotal(sortCodeAccNo, weightings);
            Assert.Equal(70, total);
        }
        [Fact]
        public void StandardExampleAdditionMatches()
        {
            MultiplyAdd mad = new MultiplyAdd();
            int[] sortCodeAccNo = new int[] { 0,0, 0, 0, 0, 0,5, 8, 1, 7, 7, 6, 3, 2 };
            int[] weightings = new int[] { 0, 0, 0, 0, 0, 0, 7, 5, 8, 3, 4, 6, 2, 1 };
            int total = mad.GetTotal(sortCodeAccNo, weightings);
            Assert.Equal(176, total);
        }
    }
}
