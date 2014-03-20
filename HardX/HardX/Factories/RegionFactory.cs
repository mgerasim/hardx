using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class RegionFactory : IFactory<RegionRepository>
    {
        public RegionRepository createRepository()
        {
            RegionRepository theRepository = new RegionRepository();
            return theRepository;
        }
    }
}