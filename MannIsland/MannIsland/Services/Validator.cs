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
        public IWeightingTotaller DoubleTotaller { get; set; } = new MultiplyAddByCharacter();
        public IWeightingTotaller OtherTotaller { get; set; } = new MultiplyAdd();

        public List<ModulusToApply> modulii { get; set; } = new List<ModulusToApply>();

        #region Setting up the sort code ranges and validation rules for them
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
                Weightings = weightings
            };
            if (pieces.Length == 18)
            {
                m.Ex = int.Parse(pieces[17]);
            }
            string whichMod = pieces[2];
            m.Divisor = 10;
            if (whichMod == "DBLAL")
            {
                m.WeightingTotaller = DoubleTotaller;
            }
            else
            {
                m.WeightingTotaller = OtherTotaller;
                if(whichMod == "MOD11")
                {
                    m.Divisor = 11;
                }
            }
            return m;
        }
        public string[] GetPieces(string line)
        {
            return line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
        #endregion
        public ModulusResult Validate(Account account)
        {
            var rules = GetRules(account);

            return new ModulusResult();
            //return Task.FromResult(new ModulusResult());
        }

        public List<ModulusToApply> GetRules(Account account)
        {
            int sortCodeNum = int.Parse(account.SortCode);
            var matches = modulii.Where(x => x.Start <= sortCodeNum && x.End >= sortCodeNum).ToList();
            return matches;
        }

        public Validator()
        {

        }
        public Validator(string baseurl)
        {
            readInFile(baseurl);
        }
    }
}
