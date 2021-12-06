using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
    public class CategoryBreadcrumbDtos
    {
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public int LevelCategory { get; set; }
    }
}
