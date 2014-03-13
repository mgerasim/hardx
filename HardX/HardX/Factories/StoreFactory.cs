using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class StoreFactory : IFactory<StoreRepository>
    {
        public StoreRepository createRepository()
        {
            StoreRepository theStoreRepository = new StoreRepository();
            return theStoreRepository;
        }
    }
}
