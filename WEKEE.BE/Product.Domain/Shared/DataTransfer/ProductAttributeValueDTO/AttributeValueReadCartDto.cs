using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO
{
    public class AttributeValueReadCartDto
    {
        public string KeyName { get; set; }
        public List<string> ValuesName { get; set; }
    }
}
