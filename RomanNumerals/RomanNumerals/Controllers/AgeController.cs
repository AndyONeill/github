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
        // Post api/Age   
        // This is a Put because Get should not pass data
        [HttpPost]
        public JsonResult Post([FromBody] NameDateOfBirth nameDateOfBirth)
        {
            int yearsAge = age.Calculate(nameDateOfBirth.DateOfBirth);
            string romanAge = numerals.Convert(yearsAge);
            Created created = new Created { Name = nameDateOfBirth.Name,
                                            CreatedAt = DateTime.Now.ToString(),
                                            Numeral=romanAge
                                          };
            return Json(created);
        }
        public AgeController(IAge _age, INumerals _numerals)
        {
            age = _age;
            numerals = _numerals;
        }
    }
}
