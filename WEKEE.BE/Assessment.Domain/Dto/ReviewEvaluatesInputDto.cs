using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Dto
{
    public class ReviewEvaluatesInputDto
    {
        /// <summary>
        /// điều kiện kiểm tra
        /// <para>1:1s, 2:1s, 3:3s, 4:4s, 5:5s, 6:new ,7:image, 8:pay</para>
        /// </summary>
        public List<int> Proviso { get; set; }
        public int Id { get; set; }
        public int Page { get; set; }
    }
}
