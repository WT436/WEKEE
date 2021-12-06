using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class DescriptionProduct
    {
        public int Id { get; set; }
        public string Blog { get; set; }
        public int ViewProduct { get; set; }
        public int LikePost { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsEnabled { get; set; }
        public int? Product { get; set; }
        public int? UseAccount { get; set; }

        public virtual Product ProductNavigation { get; set; }
    }
}
