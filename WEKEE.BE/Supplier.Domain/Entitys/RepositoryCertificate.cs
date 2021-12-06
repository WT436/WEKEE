using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Entitys
{
    public partial class RepositoryCertificate
    {
        public RepositoryCertificate()
        {
            SupplierCertificates = new HashSet<SupplierCertificate>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlCertificate { get; set; }
        public string ImageCertificate { get; set; }
        public string Descrpition { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<SupplierCertificate> SupplierCertificates { get; set; }
    }
}
