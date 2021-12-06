using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Dto
{
    public class GetEvaluatesProductDto
    {
        public int NumberStarFive { get; set; }
        public int NumberStarFour { get; set; }
        public int NumberStarThree { get; set; }
        public int NumberStarTwo { get; set; }
        public int NumberStarOne { get; set; }
        public List<ImageEvaluatesDtos> ImageReview { get; set; }
    }
}