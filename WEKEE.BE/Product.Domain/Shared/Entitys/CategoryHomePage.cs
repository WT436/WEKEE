using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class CategoryHomePage
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int NumberOrder { get; set; }
        public bool IsEnabled { get; set; }
        public int IsComponent { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual CategoryProduct Category { get; set; }
    }
}
