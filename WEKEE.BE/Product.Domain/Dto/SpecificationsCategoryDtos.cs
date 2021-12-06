using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class SpecificationsCategoryDtos
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string NameShow { get; set; }
        public int Classify { get; set; }
        public string ClassifyValues { get; set; }
        public bool IsEnabled { get; set; }
        public int CategoryMain { get; set; }
    }
}
