using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RomanNumerals.Models;

namespace RomanNumerals.Tests
{
    public class ModelCreated
    {
        [Fact]
        public void When_CreatedConvertedToCSV_GetCorrectString()
        {
            Created created = new Created { CreatedAt="2000-01-01", Name="Peter Parker", Numeral="XIX" };
            string expectedCSV = @"""2000-01-01"",""Peter Parker"",""XIX""";
            string returnedCSV = created.GetCSV();
            Assert.Equal(expectedCSV, returnedCSV);
        }
    }
}
