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
        public int Remainder { get; set; } = 0;
        public int ExpectedRemainder { get; set; } = 0;
        private Account _account;
        public bool Check(Account account)
        {
            _account = account;
            bool ok = false;
            // not sure whether I really need a list of checks 
            // but.... 
            // using a list allows me to have multiple tests and fail if any are false
            List<bool> checkResults = new List<bool>();

            // Arrays are reference types
            Array.Copy(Weightings, ModifiedWeightings,14);
            GetPreActions(Ex).ForEach(x=>x.Invoke());
            List<int> accAsNumList = new List<int>();
            foreach (char c in account.SortCodeAccountNo)
            {
                accAsNumList.Add( (int)Char.GetNumericValue(c));
            }
            checkResults.Add(WeightingTotaller.GetTotal(accAsNumList, ModifiedWeightings) % Divisor == ExpectedRemainder);

            List<Predicate<ModulusToApply>> postPredicates = GetPostPredicates(Ex);

            ok = checkResults.TrueForAll(x=>x==true) && 
                 postPredicates.TrueForAll(x=> x(this)==true);
            return ok;
        }

        public List<Predicate<ModulusToApply>> GetPostPredicates(int? ex)
        {
            List<Predicate<ModulusToApply>> predicates = new List<Predicate<ModulusToApply>>();
            Predicate<ModulusToApply> pred = x => true;

            //switch (ex)
            //{
            //    case 4:
            //        {
            //            // I don't follow how exception 4 is supposed to work.
            //            // How can the mod 11 check be ok and the remainder be anything but zero?

            //            pred = x => Remainder == (int)Char.GetNumericValue(_account.SortCodeAccountNo[12]) * 10 +
            //                                     (int)Char.GetNumericValue(_account.SortCodeAccountNo[13]);
                        
            //            break;
            //        }

            //}

            return predicates;
        }
        
        public List<Action> GetPreActions(int? ex)
        {
            List<Action> actions = new List<Action>();
            switch (ex)
            {
                case 4:
                    {
                        actions.Add
                        (
                        () => {
                            ExpectedRemainder = (int)Char.GetNumericValue(_account.SortCodeAccountNo[12]) * 10 +
                                                (int)Char.GetNumericValue(_account.SortCodeAccountNo[13]);
                            }
                        );
                        break;
                    }
                case 7:
                    {
                        actions.Add
                            (
                            () => {
                                if(_account.SortCodeAccountNo[12] == '9')
                                {
                                    for (int i = 0; i < 8; i++)
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
