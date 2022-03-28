using System;
using System.Collections.Generic;

#nullable disable

namespace Supplier.Domain.Shared.Entitys
{
    public partial class SupplierCertificate
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsLevel { get; set; }
        public bool? IsEnabled { get; set; }
        public int IdSupper { get; set; }
        public int IdCertificate { get; set; }

        public virtual RepositoryCertificate IdCertificateNavigation { get; set; }
        public virtual Supplier IdSupperNavigation { get; set; }
    }
}
