using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class ShippingFactory : IFactory<ShippingRepository>
    {
        public ShippingRepository createRepository()
        {
            ShippingRepository theRepository = new ShippingRepository();
            return theRepository;
        }
    }
}