using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO
{
    public class SpecificationProductInsertDto
    {
        public string CustomValue { get; set; }
        public string SpecificationKey { get; set; }
        public string SpecificationGroup { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
    }
}
