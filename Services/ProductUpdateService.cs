using Contacts;

using NHibernate;

using ServiceStack.Common.Extensions;
using ServiceStack.ServiceInterface;

using Services.Models;

namespace Services
{
    public class ProductUpdateService : ServiceBase<ProductUpdate>
    {
        public ISessionFactory NHSessionFactory { get; set; }

        public ProductUpdateService(ISessionFactory sessionFactory)
        {
            NHSessionFactory = sessionFactory;
        }

        protected override object Run(ProductUpdate request)
        {
            using (var session = NHSessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var existing = session.Get<Product>(request.Id)
                    .PopulateWith(request);

                tx.Commit();
            }

            return null;
        }
    }
}