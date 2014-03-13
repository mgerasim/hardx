using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using HardX.Models;

namespace Core.Domain.Repositories
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    /*
                     * var configuration = new Configuration();
                    configuration.Configure();
                    _sessionFactory = configuration.BuildSessionFactory();
                     * */
                    NHibernate.Cfg.Configuration nHibernateConfiguration =
                                      new NHibernate.Cfg.Configuration();

                    nHibernateConfiguration.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
                    nHibernateConfiguration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, HardX.Utils.DBConnection.GetConnectionString());
                    nHibernateConfiguration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.OracleClientDriver");
                    nHibernateConfiguration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.Oracle9iDialect");
                    nHibernateConfiguration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");

                    nHibernateConfiguration.AddAssembly(typeof(User).Assembly);

                    // Create session factory from configuration object
                    _sessionFactory = nHibernateConfiguration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}