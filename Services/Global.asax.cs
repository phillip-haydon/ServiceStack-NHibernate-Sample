using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Contacts;

using NHibernate;

using ServiceStack.Configuration;
using ServiceStack.WebHost.Endpoints;

using Services.Models;
using Services.NHJunk;

namespace Services
{
    public class Global : System.Web.HttpApplication
    {
        public class QueryServiceAppHost : AppHostBase
        {
            private readonly IContainerAdapter _containerAdapter;

            public QueryServiceAppHost(ISessionFactory sessionFactory)
                : base("Service Stack with Fluent NHibernate Sample", typeof(ProductFindService).Assembly)
            {
                base.Container.Register<ISessionFactory>(sessionFactory);
                base.SetConfig(new EndpointHostConfig { DebugMode = true });
            }

            public override void Configure(Funq.Container container)
            {
                container.Adapter = _containerAdapter;
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            //AutoMapper.Mapper.CreateMap<ProductInsert, Product>();

            var factory = new SessionFactoryManager().CreateSessionFactory();

            (new QueryServiceAppHost(factory)).Init();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
