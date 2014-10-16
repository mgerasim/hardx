using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class ShippingitemdistributeFactory : IFactory<ShippingitemdistributeRepository>
    {
        public ShippingitemdistributeRepository createRepository()
        {
            ShippingitemdistributeRepository theRepository = new ShippingitemdistributeRepository();
            return theRepository;
        }
    }
}