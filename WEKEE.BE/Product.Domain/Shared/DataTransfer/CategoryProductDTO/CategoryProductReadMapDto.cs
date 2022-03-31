using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.CategoryProductDTO
{
    public class CategoryProductReadMapDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public List<CategoryProductReadMapDto> Items { get; set; }
    }
}