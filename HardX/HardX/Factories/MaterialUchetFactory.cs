using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class MaterialUchetFactory : IFactory<MaterialUchetRepository>
    {
        public MaterialUchetRepository createRepository()
        {
            MaterialUchetRepository theRepository = new MaterialUchetRepository();
            return theRepository;
        }
    }
}