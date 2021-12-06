using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class CategorySelectDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public List<CategorySelectDto> Items { get; set; }
    }
}
