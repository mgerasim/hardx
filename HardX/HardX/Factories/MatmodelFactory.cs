using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class MatmodelFactory : IFactory<MatmodelRepository>
    {
        public MatmodelRepository createRepository()
        {
            MatmodelRepository theMatmodelRepository = new MatmodelRepository();
            return theMatmodelRepository;
        }
    }
}