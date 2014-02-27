using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace HardX.Core
{
    public interface IModel<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IList<T> GetAll(string condition = "", string order = "");    
    }
}