using System.Collections.Generic;

namespace RomanNumerals.Helpers
{
    public interface IFileHandler
    {
        string[] ReadLines();
        void WriteLine(string line);
        void ClearFile();
    }
}