using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using NHibernate;
using Core.Domain.Repositories;

namespace HardX.Core
{
    public class HybernoteRepository<T> : IRepository<T>
    {
        protected string _modelName;
        public void Save(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public void Update(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        public void Delete(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public T GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> GetAll(string condition = "", string order = "")
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                string strQuery = "from " + _modelName +" ";
                if (condition.Length > 0)
                {
                    strQuery += "where " + condition;
                }
                if (order.Length > 0)
                {
                    strQuery += "order " + order;
                }
                return session.CreateQuery(strQuery).List<T>();
            }
        }
    }
}