using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class ProductDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UnitProduct { get; set; }
        public bool? Fragile { get; set; }
        public string Origin { get; set; }
        public int Trademark { get; set; }
        public string Introduce { get; set; }
        public string Tag { get; set; }
        public int? Supplier { get; set; }
        public int? CategoryProduct { get; set; }
        public string ProductAlbum { get; set; }
    }
}
