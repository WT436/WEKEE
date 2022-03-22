using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class SpecificationAttributeOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public int SpecificationAttributeId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
    }
}
