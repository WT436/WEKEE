using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Dto
{
    public class RepCommentEvaluatesOutputDto
    {
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public string AvatarAccount { get; set; }
        public string NameAccount { get; set; }
        public string Comment { get; set; }
        public int NumberLike { get; set; }
        public int NumberDisLike { get; set; }
        public int NumberComment { get; set; }
        public int NumberRepost { get; set; }
        public DateTime? DateComment { get; set; }
        public bool YouLike { get; set; }
        public bool YouDisLike { get; set; }
        public List<RepCommentEvaluatesOutputDto> RepCommentEvaluates { get; set; }
    }
}
