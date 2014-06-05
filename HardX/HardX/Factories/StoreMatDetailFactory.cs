using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class StoreMatDetailFactory : IFactory<StoreMatDetailRepository>
    {
        public StoreMatDetailRepository createRepository()
        {
            StoreMatDetailRepository theRepository = new StoreMatDetailRepository();
            return theRepository;
        }
    }
}