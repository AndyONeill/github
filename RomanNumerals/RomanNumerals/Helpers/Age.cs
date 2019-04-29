using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals.Helpers
{
    public class Age : IAge
    {
        public int Calculate(DateTime dob)
        {
            int years = DateTime.Now.Year - dob.Year;

            if (dob.Month == DateTime.Now.Month &&
                             DateTime.Now.Day < dob.Day
                        || DateTime.Now.Month < dob.Month)
            {
                years--;
            }
            return years;
        }
    }
}
