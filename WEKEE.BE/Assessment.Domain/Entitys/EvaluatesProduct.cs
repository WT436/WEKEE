using System;
using System.Collections.Generic;

#nullable disable

namespace Assessment.Domain.Entitys
{
    public partial class EvaluatesProduct
    {
        public EvaluatesProduct()
        {
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
        public int Account { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual EvaluatesProduct IdEvaluatesProductNavigation { get; set; }
        public virtual ICollection<EvaluatesProduct> InverseIdEvaluatesProductNavigation { get; set; }
    }
}
