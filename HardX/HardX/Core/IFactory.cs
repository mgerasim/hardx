using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardX.Core
{
    public interface IFactory<T>
    {
        T createRepository();
    }
}