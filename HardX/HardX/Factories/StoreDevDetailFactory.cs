using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class StoreDevDetailFactory : IFactory<StoreDevDetailRepository>
    {
        public StoreDevDetailRepository createRepository()
        {
            StoreDevDetailRepository theRepository = new StoreDevDetailRepository();
            return theRepository;
        }
    }
}
