using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland
{
    public class ModulusToApply
    {
        public uint Start { get; set; }
        public uint End { get; set; }
        public int[]  Weightings { get; set; }
        public int? Ex { get; set; }

        public IWeightingTotaller WeightingTotaller { get; set; }
        public int Divisor { get; set; }


        public int[] ModifiedWeightings { get; set; } = new int[14];

        private Account _account;
        public ModulusResult Check(Account account)
        {
            _account = account;
            bool ok = false;
            // not sure whether I really need a list of checks 
            // but.... using a list allows me to have multiple tests and fail if any are false
            List<bool> checkResults = new List<bool>();

            // Arrays are reference types
            Array.Copy(Weightings, ModifiedWeightings,14);
            GetPreActions(Ex).ForEach(x=>x.Invoke());
            List<int> accAsNumList = new List<int>();
            foreach (char c in account.SortCodeAccountNo)
            {
                accAsNumList.Add( (int)Char.GetNumericValue(c));
            }
            checkResults.Add(WeightingTotaller.GetTotal(accAsNumList, ModifiedWeightings) % Divisor == 0);

            ok = checkResults.TrueForAll(x=>x==true);
            return new ModulusResult { OK=ok };
        }

        public List<Action> GetPreActions(int? ex)
        {
            List<Action> actions = new List<Action>();
            switch (ex)
            {
                case 7:
                    {
                        actions.Add
                            (
                            () => {
                                if(_account.SortCodeAccountNo[12] == '9')
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        ModifiedWeightings[i] = 0;
                                    }
                                }
                                  }
                            );
                       break;
                    }
            }
            return actions;
        }
    }
}
