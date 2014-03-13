using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class MaterialFactory : IFactory<MaterialRepository>
    {
        public MaterialRepository createRepository()
        {
            MaterialRepository theRepository = new MaterialRepository();
            return theRepository;
        }
    }
}