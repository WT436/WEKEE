using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Dto
{
    public class ReviewAccountEvaluatesOutputDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avartar { get; set; }
        public DateTime DateJoin { get; set; }
        public int UserEvaluates { get; set; }
        public int UserRepEvaluates { get; set; }
        public int UserGetFavorites { get; set; }
        public int UserGetObjections { get; set; }
    }
}
