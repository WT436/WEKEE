using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductAttributeMapping
    {
        public int Id { get; set; }
        public int FeatureProductId { get; set; }
        public int ProductAttributeValuesId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual FeatureProduct FeatureProduct { get; set; }
        public virtual ProductAttributeValue ProductAttributeValues { get; set; }
    }
}
