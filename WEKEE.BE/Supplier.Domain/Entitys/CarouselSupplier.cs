using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Entitys
{
    public partial class CarouselSupplier
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string CarouselImage { get; set; }
        public int Position { get; set; }
        public bool? IsEnabled { get; set; }
        public int? ShopSupplier { get; set; }

        public virtual ShopSupplier ShopSupplierNavigation { get; set; }
    }
}
