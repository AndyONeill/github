using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland.Infrastructure
{
    public class ValacParser
    {


        public List<ModulusToApply> GetModulii(string baseurl)
        {
            List<ModulusToApply> mods = new List<ModulusToApply>();
            var valacLines = File.ReadAllLines(baseurl + "/Resources/Valacdos.txt");
            foreach (var line in valacLines)
            {
                ModulusToApply m = GetParsedValacLine(line);
                mods.Add(m);
            }
            return mods;
        }
        public ModulusToApply GetParsedValacLine(string line)
        {
            string[] pieces = GetPieces(line);
            int[] sortCodeWeightings = new int[6];
            for (int i = 3; i < 8; i++)
            {
                sortCodeWeightings[i - 3] = int.Parse(pieces[i]);
            }
            int[] accountNoWeightings = new int[8];
            for (int i = 9; i < 17; i++)
            {
                accountNoWeightings[i - 9] = int.Parse(pieces[i]);
            }
            ModulusToApply m = new ModulusToApply
            {
                Start = uint.Parse(pieces[0]),
                End = uint.Parse(pieces[1]),
                ModVal = null,    // ToDo ??? don't forget the mod method object wossname
                SortCodeWeightings = sortCodeWeightings,
                AccountNoWeightings = accountNoWeightings
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
    }
}
