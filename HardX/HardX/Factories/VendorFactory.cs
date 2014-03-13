using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class VendorFactory : IFactory<VendorRepository>
    {
        public VendorRepository createRepository()
        {
            VendorRepository theVendorRepository = new VendorRepository();
            return theVendorRepository;
        }
    }
}