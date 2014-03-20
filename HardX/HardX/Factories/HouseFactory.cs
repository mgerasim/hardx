using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class HouseFactory : IFactory<HouseRepository>
    {
        public HouseRepository createRepository()
        {
            HouseRepository theRepository = new HouseRepository();
            return theRepository;
        }
    }
}