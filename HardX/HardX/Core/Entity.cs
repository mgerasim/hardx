using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace HardX.Core
{
    public class Entity<T>:IModel<T>
    {
        protected IRepository<T> _repository;

        public virtual void Save(T entity)
        {
            _repository.Save(entity);            
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IList<T> GetAll(string condition = "", string order = "")
        {
            return _repository.GetAll(condition, order);
        }
    }
}