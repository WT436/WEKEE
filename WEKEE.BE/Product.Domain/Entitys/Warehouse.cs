using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdminComment { get; set; }
        public int AddressId { get; set; }
    }
}
