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

    public class ServiceAge
    {
        private AgeController ageController;
        private FileHandler fileHandler = new FileHandler();
        private Age age = new Age();
        private Numerals numerals = new Numerals();
        private CSVtoCreated csvToCreated = new CSVtoCreated();
        public ServiceAge()
        {
            ageController = new AgeController(age, numerals, fileHandler, csvToCreated);
        }

        [Fact(Timeout = 50)]
        public void When_CallingPost_ExpectValidReturnJSonInBody()
        {
            var dob = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };

            JsonResult result = ageController.Post(dob);
            Created created = (Created)result.Value;

            Assert.Equal("Miles Davis", created.Name);
            // This will break in some months so a more sophisticated way of working out DoB would be an idea
            Assert.Equal("XX", created.Numeral);
        }
        [Fact(Timeout = 50)]
        public void When_FileClearedAndCallPost_Expect_OneLineInFile()
        {
            fileHandler.ClearFile();

            var dob = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };
            JsonResult result = ageController.Post(dob);

            string[] createdLines = fileHandler.ReadLines();

            Assert.Single(createdLines);
        }
        [Fact]
        public async void When_FileClearedAndCallPostTwice_Expect_TwoLinesInFile()
        {
            // Tests can occasionally try and grab the file at the same time
            // A database would be advisable for real world code
            await Task.Delay(50);
            fileHandler.ClearFile();

            var dob = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };

            JsonResult result = ageController.Post(dob);
                       result = ageController.Post(dob);
            string[] createdLines = fileHandler.ReadLines();

            Assert.Equal(2,createdLines.Length);
        }
        [Fact(Timeout = 50)]
        public void When_FileClearedAndCallPostTwice_Expect_TwoCreatedsFromGet()
        {
            fileHandler.ClearFile();

            var dob1 = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Miles Davis" };
            JsonResult result = ageController.Post(dob1);
            var dob2 = new NameDateOfBirth { DateOfBirth = new DateTime(1999, 02, 28), Name = "Peter Parker" };
            result = ageController.Post(dob2);
            JsonResult jsonFromFile = ageController.Get();
            Created[] createds = (Created[])jsonFromFile.Value;

            Assert.Equal("Miles Davis", createds[0].Name);
            Assert.Equal("Peter Parker", createds[1].Name);
        }
    }
}
