using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductAttributeDTO
{
    public class ProductAttributeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Types { get; set; }
        public string TypesName { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
