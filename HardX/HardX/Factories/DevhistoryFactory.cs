using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class DevhistoryFactory : IFactory<DevhistoryRepository>
    {
        public DevhistoryRepository createRepository()
        {
            DevhistoryRepository theRepository = new DevhistoryRepository();
            return theRepository;
        }
    }
}