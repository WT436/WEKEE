using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO
{
    public class SpecificationProductInsertDto
    {
        public string CustomValue { get; set; }
        public int SpecificationId { get; set; }
        public int AttributeTypeId { get; set; }
        public bool AllowFiltering { get; set; }
    }
}
