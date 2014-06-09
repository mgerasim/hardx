using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class DeviceRepository : HybernoteRepository<HardX.Models.Device>
    {
        public DeviceRepository()
        {
            this._modelName = "Device";
        }
    }    
}