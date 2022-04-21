using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ImageEvaluatesProduct
    {
        public int Id { get; set; }
        public int? ImageProductId { get; set; }
        public int? EvaluatesProductId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual EvaluatesProduct EvaluatesProduct { get; set; }
        public virtual ImageProduct ImageProduct { get; set; }
    }
}
