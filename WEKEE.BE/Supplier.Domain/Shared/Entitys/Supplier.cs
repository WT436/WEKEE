using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Shared.Entitys
{
    public partial class Supplier
    {
        public Supplier()
        {
            ShopSuppliers = new HashSet<ShopSupplier>();
            SupplierCertificates = new HashSet<SupplierCertificate>();
            SupplierMappings = new HashSet<SupplierMapping>();
        }

        public int Id { get; set; }
        public decimal? NumberPhone { get; set; }
        public string Email { get; set; }
        public string PassWordShop { get; set; }
        public string HaskPass { get; set; }
        public string NameShop { get; set; }
        public string LinkShop { get; set; }
        public string Adress { get; set; }
        public string Url { get; set; }
        public string Hosts { get; set; }
        public string CompanyVat { get; set; }
        public bool? SslEnabled { get; set; }
        public int? DefaultLanguageId { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<ShopSupplier> ShopSuppliers { get; set; }
        public virtual ICollection<SupplierCertificate> SupplierCertificates { get; set; }
        public virtual ICollection<SupplierMapping> SupplierMappings { get; set; }
    }
}
