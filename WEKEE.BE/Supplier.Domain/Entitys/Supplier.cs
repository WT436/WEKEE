using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Entitys
{
    public partial class Supplier
    {
        public Supplier()
        {
            ShopSuppliers = new HashSet<ShopSupplier>();
            SupplierCertificates = new HashSet<SupplierCertificate>();
        }

        public int Id { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public string PassWordShop { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public string NameShop { get; set; }
        public string LinkShop { get; set; }
        public string Adress { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnabled { get; set; }
        public int? UseAccount { get; set; }

        public virtual ICollection<ShopSupplier> ShopSuppliers { get; set; }
        public virtual ICollection<SupplierCertificate> SupplierCertificates { get; set; }
    }
}
