using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MannIsland.Services;
using JsonApiDotNetCore;

namespace MannIsland.Controllers
{
    public class ValidateController : Controller
    {
        private IValidator validator;

        // This is an api that returns json because I didn't have enough time to work out how
        // a JSON API would differ
        [HttpGet]
        public JsonResult Account(String SortCode, String AccountNo)
        {
            Account account = new Account { SortCode=SortCode, AccountNo=AccountNo };
            return Json(validator.Validate(account));
        }

        public ValidateController(IValidator _validator)
        {
            validator = _validator;
        }
    }
}