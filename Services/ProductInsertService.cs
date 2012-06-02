using Contacts;

using NHibernate;

using ServiceStack.Common.Extensions;
using ServiceStack.ServiceInterface;

using Services.Models;

namespace Services
{
    public class ProductInsertService : ServiceBase<ProductInsert>
    {
        public ISessionFactory NHSessionFactory { get; set; }

        public ProductInsertService(ISessionFactory sessionFactory)
        {
            NHSessionFactory = sessionFactory;
        }

        protected override object Run(ProductInsert request)
        {
            using (var session = NHSessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var result = request.TranslateTo<Product>();

                session.Save(result);

                tx.Commit();
            }

            return null;
        }
    }
}