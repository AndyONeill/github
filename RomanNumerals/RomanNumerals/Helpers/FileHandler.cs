using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RomanNumerals.Helpers
{
    // There is no checking for locks in this which means it's not exactly production ready
    public class FileHandler : IFileHandler
    {
        private string fileUrl = string.Empty;
        public void WriteLine(string line)
        {
            // C:\Users\Andrew\AppData\Local\Temp\Createds.csv for me
            File.AppendAllLines(fileUrl, new[] { line });
        }

        public FileHandler()
        {
            fileUrl = Path.Combine(System.IO.Path.GetTempPath(), "Createds.csv");
        }
        public string[] ReadLines()
        {
            if (File.Exists(fileUrl))
            {
                return File.ReadAllLines(fileUrl);
            }
            return new string[] {string.Empty};
        }
        public void ClearFile()
        {
            if(File.Exists(fileUrl))
            {
                // Could conceivably be locked or something
                File.Delete(fileUrl);
            }
        }
    }
}
