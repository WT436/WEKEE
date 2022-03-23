using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductPictureMapping
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public int ProductId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ImageProduct Picture { get; set; }
        public virtual Product Product { get; set; }
    }
}
