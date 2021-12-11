using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class HighlightProduct
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public string Values { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IsStatus { get; set; }
        public int? Product { get; set; }

        public virtual SpecificationsCategory KeyNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
