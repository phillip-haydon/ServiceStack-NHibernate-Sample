using System;

using Contacts;

using NHibernate;

using ServiceStack.Common.Extensions;
using ServiceStack.ServiceInterface;

namespace Services
{
    public class ProductFindService : ServiceBase<ProductFind>
    {
        public ISessionFactory NHSessionFactory { get; set; }

        public ProductFindService(ISessionFactory sessionFactory)
        {
            NHSessionFactory = sessionFactory;
        }

        protected override object Run(ProductFind request)
        {
            using (var session = NHSessionFactory.OpenSession())
            {
                var result = session.Load<Models.Product>(request.Id);

                return new ProductFindResponse
                {
                    Result = result.TranslateTo<ProductFindResponse.Product>()
                };
            }
        }
    }
}