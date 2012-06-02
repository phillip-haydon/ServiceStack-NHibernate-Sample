using System;

using ServiceStack.ServiceInterface.ServiceModel;

namespace Contacts
{
    public class ProductFindResponse : IHasResponseStatus
    {
        public class Product
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
            public string Description { get; set; }
        }

        public Product Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}