using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class StreetFactory : IFactory<StreetRepository>
    {
        public StreetRepository createRepository()
        {
            StreetRepository theRepository = new StreetRepository();
            return theRepository;
        }
    }
}