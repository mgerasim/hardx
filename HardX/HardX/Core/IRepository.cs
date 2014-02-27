using System;
using System.Collections.Generic;
using System.Text;
using HardX.Models;
using Core.Domain.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace Core
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IList<T> GetAll(string condition = "", string order = "");
    }
}