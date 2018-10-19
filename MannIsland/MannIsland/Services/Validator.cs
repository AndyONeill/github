using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using MannIsland.Infrastructure;

namespace MannIsland.Services
{
    public class Validator : IValidator
    {

        public List<ModulusToApply> Modulii { get; set; } = new List<ModulusToApply>();
        public Validator(string baseurl)
        {
            ValacParser vp = new ValacParser();
            Modulii = vp.GetModulii(baseurl);
        }



        public Task<ModulusResult> Validate(Account account)
        {
            return Task.FromResult(new ModulusResult());
        }
    }
}
