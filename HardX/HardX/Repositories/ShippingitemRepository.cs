using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class ShippingitemRepository: HybernoteRepository<HardX.Models.Shippingitem>
        {
            public ShippingitemRepository()
            {
                this._modelName = "Shippingitem";
            }
        }  
}