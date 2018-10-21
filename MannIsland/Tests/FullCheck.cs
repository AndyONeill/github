using System;
using Xunit;
using MannIsland.Services;
using MannIsland;
using System.Collections.Generic;

namespace Tests
{
    public class FullCheck
    {
        private Validator val;
        public FullCheck()
        {
            val = new Validator(".");
        }

        [Fact]
        public void DoubleExamplePasses()
        {
            Account account = new Account { SortCode = "499273", AccountNo = "12345678" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void StandardExamplePasses()
        {
            Account account = new Account { SortCode = "000000", AccountNo = "58177632" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults1()
        {
            Account account = new Account { SortCode = "404784", AccountNo = "70872490" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults2()
        {
            Account account = new Account { SortCode = "404784", AccountNo = "70872491" };
            var result = val.Validate(account);
            Assert.False(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults3()
        {
            Account account = new Account { SortCode = "205132", AccountNo = "13537846" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults4()
        {
            Account account = new Account { SortCode = "205132", AccountNo = "23537846" };
            var result = val.Validate(account);
            Assert.False(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults5()
        {
            Account account = new Account { SortCode = "090128", AccountNo = "03745521" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults6()
        {
            Account account = new Account { SortCode = "090128", AccountNo = "13745521" };
            var result = val.Validate(account);
            Assert.False(result.OK);
        }

        [Fact]
        public void SamplesGiveExpectedResults7()
        {
            Account account = new Account { SortCode = "560003", AccountNo = "13354647" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void SamplesGiveExpectedResults8()
        {
            Account account = new Account { SortCode = "560003", AccountNo = "14354647" };
            var result = val.Validate(account);
            Assert.False(result.OK);
        }


// Expected results from section 7
        [Fact]
        public void TestCase1()
        {
            Account account = new Account { SortCode = "089999", AccountNo = "66374958" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void TestCase2()
        {
            Account account = new Account { SortCode = "107999", AccountNo = "88837491" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void TestCase3()
        {
            Account account = new Account { SortCode = "202959", AccountNo = "63748472" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void TestCase11Exception4()
        {
            Account account = new Account { SortCode = "134020", AccountNo = "63849203" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
        [Fact]
        public void TestCase17Exception7()
        {
            Account account = new Account { SortCode = "772798", AccountNo = "99345694" };
            var result = val.Validate(account);
            Assert.True(result.OK);
        }
    }
}
