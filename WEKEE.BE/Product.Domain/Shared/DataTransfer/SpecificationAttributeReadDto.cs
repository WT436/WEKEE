using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer
{
    public class SpecificationAttributeReadDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int CategoryProductId { get; set; }
        public string GroupSpecification { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
