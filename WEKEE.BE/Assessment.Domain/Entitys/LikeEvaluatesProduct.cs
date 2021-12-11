using System;
using System.Collections.Generic;

#nullable disable

namespace Assessment.Domain.Entitys
{
    public partial class LikeEvaluatesProduct
    {
        public int Id { get; set; }
        public bool? Islike { get; set; }
        public bool? Isdislike { get; set; }
        public int LevelEvaluates { get; set; }
        public int IdEvaluates { get; set; }
        public int Account { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
