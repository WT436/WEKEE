using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Shared.Entitys
{
    public partial class ShopSupplier
    {
        public ShopSupplier()
        {
            CarouselSuppliers = new HashSet<CarouselSupplier>();
        }

        public int Id { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }
        public string Descrpition { get; set; }
        public int Follow { get; set; }
        public int? Supplier { get; set; }
        public int? Seo { get; set; }

        public virtual Supplier SupplierNavigation { get; set; }
        public virtual ICollection<CarouselSupplier> CarouselSuppliers { get; set; }
    }
}
