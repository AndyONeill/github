using System;
using System.Collections.Generic;
using System.Text;
using RomanNumerals.Helpers;
using Xunit;

namespace RomanNumerals.Tests
{
    public class AgeChecking
    {
        private Age age = new Age();
        [Fact]
        public void When_1YearOld_Expect_1()
        {
            DateTime dob = DateTime.Now.AddYears(-1).AddDays(-1);
            int result = age.Calculate(dob);
            Assert.Equal(1, result);
        }
        [Fact]
        public void When_21YearOld_Expect_21()
        {
            DateTime dob = DateTime.Now.AddYears(-21).AddDays(-364);
            int result = age.Calculate(dob);
            Assert.Equal(21, result);
        }
        [Fact]
        public void When_22YearOld_Expect_22()
        {
            DateTime dob = DateTime.Now.AddYears(-21).AddDays(-365);
            int result = age.Calculate(dob);
            Assert.Equal(22, result);
        }
    }
}
