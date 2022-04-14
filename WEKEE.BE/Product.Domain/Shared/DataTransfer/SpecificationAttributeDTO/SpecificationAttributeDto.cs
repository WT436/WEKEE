using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO
{
    public class SpecificationAttributeDto
    {
        public string CustomValue { get; set; }
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
    }
}
