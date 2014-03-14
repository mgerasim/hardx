using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class AreaFactory : IFactory<AreaRepository>
    {
        public AreaRepository createRepository()
        {
            AreaRepository theRepository = new AreaRepository();
            return theRepository;
        }
    }
}