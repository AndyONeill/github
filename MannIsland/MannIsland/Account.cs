using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland
{
    public class Account
    {
       public string SortCode { get; set; }
       public string AccountNo { get; set; }

       public string SortCodeAccountNo => SortCode + AccountNo;
    }
}
