using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals.Models
{
    public class Created
    {
        public string CreatedAt { get; set; }
        public string Name { get; set; }
        public string Numeral { get; set; }

        // For a class with many properties or generic class I could iterate properties using reflection or the like
        // Since this class only has 3 properties, that would be massive overkill though.
        public  string GetCSV()
        {
            return $@"""{CreatedAt:yyyy-MM-dd}"",""{Name}"",""{Numeral}""";
        }
    }
}
