using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class TownFactory : IFactory<TownRepository>
    {
        public TownRepository createRepository()
        {
            TownRepository theRepository = new TownRepository();
            return theRepository;
        }
    }
}