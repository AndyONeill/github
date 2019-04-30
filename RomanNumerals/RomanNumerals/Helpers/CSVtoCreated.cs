using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RomanNumerals.Models;

namespace RomanNumerals.Helpers
{
    public class CSVtoCreated
    {
        public Created GetCreated(string csv)
        {
            string[] props = csv.Split(",");

            for (int i = 0; i < 3; i++)
            {
                props[i] = props[i].Replace("\"", "");
            }
            Created created = new Created
            {
                CreatedAt = props[0],
                Name = props[1],
                Numeral = props[2]
            };
            return created;
        }
    }
}
