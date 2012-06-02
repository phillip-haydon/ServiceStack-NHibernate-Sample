using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentNHibernate.Mapping;

namespace Services.Models
{
    public class Product
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, "id").GeneratedBy.GuidComb();

            Map(x => x.Name, "name");
            Map(x => x.Description, "description");
        }
    }
}