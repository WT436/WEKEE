using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductDTO
{
    public class ProductCartReadDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DisplayOrder { get; set; }
        public bool MainProduct { get; set; }
        public int IdImg { get; set; }
    }
}
