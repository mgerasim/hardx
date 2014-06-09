using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class DeviceFactory : IFactory<DeviceRepository>
    {
        public DeviceRepository createRepository()
        {
            DeviceRepository theRepository = new DeviceRepository();
            return theRepository;
        }
    }
}