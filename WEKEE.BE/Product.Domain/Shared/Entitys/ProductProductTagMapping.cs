﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductProductTagMapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductTagId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductTag ProductTag { get; set; }
    }
}
