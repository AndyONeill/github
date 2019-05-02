using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RomanNumerals.Controllers;
using RomanNumerals.Models;
using RomanNumerals.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RomanNumerals.Tests
{
    public class AgeControllerEndToEndCalls
    {
        private AgeController ageController;
        private FileHandler fileHandler = new FileHandler();
        private Age age = new Age();
        private Numerals numerals = new Numerals();
        private CSVtoCreated csvToCreated = new CSVtoCreated();
        public AgeControllerEndToEndCalls()
        {
            ageController = new AgeController(age, numerals, fileHandler, csvToCreated);
        }

        [Fact(Timeout = 60)]
        public void When_CallingValidPost_ExpectValidReturnJSonInBody()
        {
            var dob = new NameDateOfBirth { DateOfBirth = DateTime.Now.AddYears(-20), Name = "Miles Davis" };

            IActionResult result = ageController.Post(dob);
            Created created = (Created)((JsonResult)result).Value;

            Assert.Equal("Miles Davis", created.Name);
            Assert.Equal("XX", created.Numeral);
        }
        [Fact(Timeout = 60)]
        public async void When_FileClearedAndCallPost_Expect_OneLineInFile()
        {
            // Tests can occasionally try and grab the file at the same time
            // A database would be advisable for real world code
            await Task.Delay(30);
            fileHandler.ClearFile();

            var dob = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };
            IActionResult result = ageController.Post(dob);

            string[] createdLines = fileHandler.ReadLines();

            Assert.Single(createdLines);
        }
        [Fact(Timeout = 60)]
        public async void When_FileClearedAndCallPostTwice_Expect_TwoLinesInFile()
        {
            await Task.Delay(30);
            fileHandler.ClearFile();

            var dob = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };

            IActionResult result = ageController.Post(dob);
                          result = ageController.Post(dob);
            string[] createdLines = fileHandler.ReadLines();

            Assert.Equal(2,createdLines.Length);
        }
        [Fact(Timeout = 60)]
        public async void When_FileClearedAndCallPostTwice_Expect_TwoCreatedsReturnedFromGet()
        {
            await Task.Delay(30);
            fileHandler.ClearFile();

            var dob1 = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };
            IActionResult result = ageController.Post(dob1);
            var dob2 = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Peter Parker" };
            result = ageController.Post(dob2);
            JsonResult jsonFromFile = ageController.Get();
            Created[] createds = (Created[])jsonFromFile.Value;

            Assert.Equal("Miles Davis", createds[0].Name);
            Assert.Equal("Peter Parker", createds[1].Name);
        }
        [Fact]
        public void When_AgeIsZero_Expect_400()
        {
            var dob = new NameDateOfBirth { DateOfBirth = DateTime.Now.AddDays(-364), Name = "Miles Davis" };

            IActionResult result = ageController.Post(dob);

            int status = ((StatusCodeResult)result).StatusCode;

            Assert.Equal(400, status);
        }
        [Fact]
        public void When_NameTooShort_Expect_400()
        {
            var dob = new NameDateOfBirth { DateOfBirth = DateTime.Now.AddYears(2), Name = "Miles" };

            IActionResult result = ageController.Post(dob);

            int status = ((StatusCodeResult)result).StatusCode;

            Assert.Equal(400, status);
        }
    }
}
