using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals.Helpers
{
    public class Numerals : INumerals
    {
        int[] sortedValues = new int[] { 1,4,5,9,10,40,50,90,100,400,500,900,1000    };
        string[] matchingNumerals = new string[]
            { "I", "IV", "V", "IX", "X","XL", "L", "XC", "C","CD", "D","CM","M"};

        // Loops while there is a remainder
        //    Finds the highest number less than or equal to remainder
        //    Appends the roman numeral(s)
        //    substracts number from remainder
        public string Convert(int num)
        {
            string result = "";
            int remainder = num;

            while(remainder > 0)
            {
                int ix = Array.BinarySearch(sortedValues, remainder);
                if (ix < 0)
                {
                    ix = ~ix - 1;  // No matching entry gives complement of index of next higher 
                                   // so complement with that ~ and subtract 1 for next lower
                }
                result += matchingNumerals[ix];
                remainder -= sortedValues[ix];
            }
            return result;
        }
    }
}
