using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.CategoryProductDTO
{
    public class CategoryProductAddProductDto
    {
        public List<int> IdCategory { get; set; }
        public int CategoryMain { get; set; }
    }
}
