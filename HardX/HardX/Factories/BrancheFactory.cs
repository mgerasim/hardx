using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class BrancheFactory:IFactory<BrancheRepository>
    {
        public BrancheRepository createRepository()
        {
            BrancheRepository theBrancheRepository = new BrancheRepository();
            return theBrancheRepository;
        }
    }
}