using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Dto
{
    public class EvaluatesProductDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StarNumber { get; set; }
        public List<string> PinFeeling { get; set; }
        public List<string> Image { get; set; }
        public int Product { get; set; }
        public int Account { get; set; }
        public int LevelEvaluates { get; set; }
    }
}
