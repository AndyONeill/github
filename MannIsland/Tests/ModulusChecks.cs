using System;
using Xunit;
using MannIsland.Services;
using MannIsland;
using System.Collections.Generic;

namespace Tests
{
    public class ModulusChecks
    {
        private Validator val;
        public ModulusChecks()
        {
            val = new Validator(".");
        }
        [Fact]
        public void DoubleExampleAdditionMatches()
        {
            MultiplyAddByCharacter mac = new MultiplyAddByCharacter();
            List<int> sortCodeAccNo = new List<int> { 4, 9, 9, 2, 7, 3, 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] weightings = new int[] { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int total = mac.GetTotal(sortCodeAccNo, weightings);
            Assert.Equal(70, total);
        }
        [Fact]
        public void StandardExampleAdditionMatches()
        {
            MultiplyAdd mad = new MultiplyAdd();
            List<int> sortCodeAccNo = new List<int> { 0, 0, 0, 0, 0, 0, 5, 8, 1, 7, 7, 6, 3, 2 };
            int[] weightings = new int[]  { 0, 0, 0, 0, 0, 0, 7, 5, 8, 3, 4, 6, 2, 1 };
            int total = mad.GetTotal(sortCodeAccNo, weightings);
            Assert.Equal(176, total);
        }
        [Fact]
        public void CheckAccountsWillMatchRules()
        {
            Account acc = new Account { SortCode = "070116", AccountNo = "12345678" };
            var rools = val.GetRules(acc);
            Assert.Equal(2, rools.Count);
        }
        [Fact]
        public void CheckInvalidAccountsMatchesNoRules()
        {
            // 999999 is out of valid range so no rules should qualify
            Account acc = new Account { SortCode = "999999", AccountNo = "12345678" };
            var rools = val.GetRules(acc);
            Assert.Empty(rools);
        }
        [Fact]
        public void Exception7ShouldMeanAPreAction()
        {
            ModulusToApply mod2App = new ModulusToApply();
            List<Action> noActions = mod2App.GetPreActions(new int?());
            Assert.Empty(noActions);
            List<Action> actions = mod2App.GetPreActions(7);
            Assert.Single(actions);
        }
    }
}
