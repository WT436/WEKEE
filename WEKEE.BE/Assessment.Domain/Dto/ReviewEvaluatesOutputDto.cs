using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Dto
{
    public class ReviewEvaluatesOutputDto
    {
        public ReviewAccountEvaluatesOutputDto AccountReview { get; set; }
        public int IdReview { get; set; }
        public string Content { get; set; }
        public int StarNumber { get; set; }
        public string PinFeeling { get; set; }
        public List<ImageEvaluatesDtos> Image { get; set; }
        public DateTime? DateReview { get; set; }
        public int LikeReview { get; set; }
        public int DislikeReview { get; set; }
        public int CommentReview { get; set; }
        // you and comment
        public bool YouLike { get; set; }
        public bool YouDisLike { get; set; }
        // rep comment
        public List<RepCommentEvaluatesOutputDto> RepCommentEvaluates { get; set; }
    }
}
