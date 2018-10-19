using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannIsland.Services
{
    public interface IValidator
    {
        Task<ModulusResult> Validate(Account account);
    }
}
