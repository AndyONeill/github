using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanNumerals.Models;
using RomanNumerals.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace RomanNumerals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AgeController : Controller
    {
        private IAge age;
        private INumerals numerals;
        private IFileHandler fileHandler;
        private CSVtoCreated csvToCreated;
        // Post api/Age   
        // This is a Put because Get should not pass data
        [HttpPost]
        public IActionResult Post([FromBody] NameDateOfBirth nameDateOfBirth)
        {
            // ToDo 
            // Validate input and return 400 if date invalid or name too short
            int yearsAge = age.Calculate(nameDateOfBirth.DateOfBirth);
            if(yearsAge < 1 || (nameDateOfBirth.Name?.Length ?? 0) < 6)
            {
                return BadRequest();
            }

            string romanAge = numerals.Convert(yearsAge);
            Created created = new Created { Name = nameDateOfBirth.Name,
                                            CreatedAt = DateTime.Now.ToString(),
                                            Numeral=romanAge
                                          };
            fileHandler.WriteLine(created.GetCSV());
            return Json(created);
        }
        // Return json array of "Created" records from the CSV
        [HttpGet]
        public JsonResult Get()
        {
            string[] lines = fileHandler.ReadLines();
            List<Created> createds = new List<Created>();
            foreach (string line in lines)
            {
               createds.Add(csvToCreated.GetCreated(line));
            }

            return Json(createds.ToArray());
        }
        public AgeController(IAge _age, INumerals _numerals, IFileHandler _fileHandler, CSVtoCreated _csvToCreated)
        {
            age = _age;
            numerals = _numerals;
            fileHandler = _fileHandler;
            csvToCreated = _csvToCreated;
        }
    }
}
