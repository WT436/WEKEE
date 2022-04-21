using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class LikeEvaluatesProduct
    {
        public int Id { get; set; }
        public bool? Islike { get; set; }
        public bool? Isdislike { get; set; }
        public int EvaluatesId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
