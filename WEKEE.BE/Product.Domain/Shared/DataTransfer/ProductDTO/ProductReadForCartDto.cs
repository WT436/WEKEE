using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductDTO
{
    public class ProductReadForCartDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DisplayOrder { get; set; }
        public bool MainProduct { get; set; }
        public int IdImg { get; set; }
        public string IMGS80x80 { get; set; }
        public string Values { get; set; }
        public string Name { get; set; }

    }
}
