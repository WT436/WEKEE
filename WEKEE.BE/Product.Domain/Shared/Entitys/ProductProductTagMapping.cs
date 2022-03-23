using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductProductTagMapping
    {
        public int ProductId { get; set; }
        public int ProductTagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductTag ProductTag { get; set; }
    }
}
