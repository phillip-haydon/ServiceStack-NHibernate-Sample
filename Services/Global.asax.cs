using System;
using System.Web;

using NHibernate;

using ServiceStack.Configuration;
using ServiceStack.WebHost.Endpoints;

using Services.NHJunk;

namespace Services
{
    public class Global : HttpApplication
    {
        public class SampleServiceAppHost : AppHostBase
        {
            private readonly IContainerAdapter _containerAdapter;

            public SampleServiceAppHost(ISessionFactory sessionFactory)
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
            var factory = new SessionFactoryManager().CreateSessionFactory();

            (new SampleServiceAppHost(factory)).Init();
        }
    }
}
