using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class FeatureProduct
    {
        public FeatureProduct()
        {
            ProductAttributeMappings = new HashSet<ProductAttributeMapping>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal LengthAdjustment { get; set; }
        public decimal WidthAdjustment { get; set; }
        public decimal HeightAdjustment { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int DisplayOrder { get; set; }
        public int PictureId { get; set; }
        public int ImageSquaresPictureId { get; set; }
        public bool MainProduct { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ImageProduct ImageSquaresPicture { get; set; }
        public virtual ImageProduct Picture { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }
    }
}
