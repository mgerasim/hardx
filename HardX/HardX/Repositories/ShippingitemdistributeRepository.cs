using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class ShippingitemdistributeRepository: HybernoteRepository<HardX.Models.Shippingitemdistribute>
        {
            public ShippingitemdistributeRepository()
            {
                this._modelName = "Shippingitemdistribute";
            }
        }  
}