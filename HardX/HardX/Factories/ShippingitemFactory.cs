using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class ShippingitemFactory : IFactory<ShippingitemRepository>
    {
        public ShippingitemRepository createRepository()
        {
            ShippingitemRepository theRepository = new ShippingitemRepository();
            return theRepository;
        }
    }
}