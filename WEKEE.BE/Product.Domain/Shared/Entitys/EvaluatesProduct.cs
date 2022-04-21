using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class EvaluatesProduct
    {
        public EvaluatesProduct()
        {
            ImageEvaluatesProducts = new HashSet<ImageEvaluatesProduct>();
            InverseIdEvaluatesProductNavigation = new HashSet<EvaluatesProduct>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int? StarNumber { get; set; }
        public string PinFeeling { get; set; }
        public string TagAccount { get; set; }
        public int LevelEvaluates { get; set; }
        public int? IdEvaluatesProduct { get; set; }
        public int Product { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual EvaluatesProduct IdEvaluatesProductNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
        public virtual ICollection<ImageEvaluatesProduct> ImageEvaluatesProducts { get; set; }
        public virtual ICollection<EvaluatesProduct> InverseIdEvaluatesProductNavigation { get; set; }
    }
}
