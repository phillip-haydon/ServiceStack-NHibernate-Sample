using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Services.NHJunk
{
    public class SessionFactoryManager
    {
        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString")).AdoNetBatchSize(50))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(x =>
                {
                    x.SetProperty("generate_statistics", "true");
                    new SchemaUpdate(x).Execute(false, true);
                })
                .BuildSessionFactory();
        }
    }
}