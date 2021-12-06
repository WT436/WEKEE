using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class ProductCardDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameUnitProduct { get; set; }
        public bool? Fragile { get; set; }
        public string Origin { get; set; }
        public int? Trademark { get; set; }
        public string NameTrademark { get; set; }
        public string Introduce { get; set; }
        public string Tag { get; set; }
        public int? Supplier { get; set; }
    }
}
