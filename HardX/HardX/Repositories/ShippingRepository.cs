using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class ShippingRepository: HybernoteRepository<HardX.Models.Shipping>
        {
            public ShippingRepository()
            {
                this._modelName = "Shipping";
            }
        }  
}