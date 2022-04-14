using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.CategoryProductDTO
{
    public class CategoryBreadcrumbDtos
    {
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public int LevelCategory { get; set; }
    }
}
