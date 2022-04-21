using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.CategoryHomePageDTO
{
    public class CategoryHomePageReadDto
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string NameCategory { get; set; }
        public string UrlCategory { get; set; }
        public string IconCategory { get; set; }
        public string CategoryMainName { get; set; }
        public int NumberOrder { get; set; }
        public bool IsEnabled { get; set; }
        public string IsComponent { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
