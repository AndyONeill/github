using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace MannIsland.Services
{
    public class Validator : IValidator
    {
        public Validator()
        {
           
        }

        public Validator(string baseurl)
        {
            readInFile(baseurl);
        }

        public List<ModulusToApply> modulii { get; set; } = new List<ModulusToApply>();

        private void readInFile(string baseurl)
        {
            List<ModulusToApply> mods = new List<ModulusToApply> ();
            var valacLines = File.ReadAllLines(baseurl + "/Resources/Valacdos.txt");
            foreach (var line in valacLines)
            {
                ModulusToApply m = GetParsedValacLine(line);
                mods.Add(m);
            }
            modulii = mods;
        }
        public ModulusToApply GetParsedValacLine(string line)
        {
            string[] pieces = GetPieces(line);
            int[] weightings = new int[14];
            for (int i = 3; i < 17; i++)
            {
                weightings[i - 3] = int.Parse(pieces[i]);
            }
            ModulusToApply m = new ModulusToApply
            {
                Start = uint.Parse(pieces[0]),
                End = uint.Parse(pieces[1]),
                ModVal = null,    // ToDo ??? don't forget the mod method object wossname
                Weightings = weightings
            };
            if (pieces.Length == 18)
            {
                m.Ex = int.Parse(pieces[17]);
            }
            return m;
        }
        public string[] GetPieces(string line)
        {
            return line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        public Task<ModulusResult> Validate(Account account)
        {
            return Task.FromResult(new ModulusResult());
        }
    }
}
