using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RomanNumerals.Helpers;
using RomanNumerals.Models;
namespace RomanNumerals.Tests
{
    public class FileHandlerChecking
    {
        private FileHandler fileHandler = new FileHandler();
        [Fact]
        public void When_WritingOneLine_ExpectOneLineInFile()
        {
            fileHandler.ClearFile();
            fileHandler.WriteLine("x");
            string[] createdLines = fileHandler.ReadLines();
            Assert.Single(createdLines);
        }
        [Fact]
        public void When_WritingTwoLines_ExpectTwoLinesInFile()
        {
            fileHandler.ClearFile();
            fileHandler.WriteLine("x");
            fileHandler.WriteLine("y");
            string[] createdLines = fileHandler.ReadLines();
            Assert.Equal(2,createdLines.Length);
        }
    }
}
