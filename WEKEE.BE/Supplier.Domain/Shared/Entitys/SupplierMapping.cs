using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Shared.Entitys
{
    public partial class SupplierMapping
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UseAccount { get; set; }
        public bool? IsBoss { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
