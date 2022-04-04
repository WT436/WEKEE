using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductTagDTO
{
    public class ProductTagInsertDto
    {
        public string Name { get; set; }
        public int CreateBy { get; set; }
    }
}
