using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MannIsland.Services;

namespace MannIsland
{
    public class DummyValidatorCall
    {
        private IValidator validator;
        public DummyValidatorCall(IValidator _validator)
        {
            validator = _validator;
        }

    }
}
