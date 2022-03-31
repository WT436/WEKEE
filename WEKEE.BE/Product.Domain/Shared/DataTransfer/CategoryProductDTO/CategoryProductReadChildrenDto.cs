using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.CategoryProductDTO
{
    public class CategoryProductReadChildrenDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public string IconCategory { get; set; }
        public int LevelCategory { get; set; }
        public int? CategoryMain { get; set; }
        public string CategoryMainName { get; set; }
        public int NumberOrder { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public CategoryProductReadChildrenDto Children {get; set;}
    }
}
