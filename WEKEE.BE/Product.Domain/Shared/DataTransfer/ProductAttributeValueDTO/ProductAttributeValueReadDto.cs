using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO
{
    public class ProductAttributeValueReadDto
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public string KeyName { get; set; }
        public string Values { get; set; }
    }
}
