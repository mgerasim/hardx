using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class VendorRepository : HybernoteRepository<HardX.Models.Vendor>
    {
        public VendorRepository()
        {
            this._modelName = "Vendor";
        }
    }
}