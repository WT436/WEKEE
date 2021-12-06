using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Domain.Dto
{
    public class SupplierDtos
    {
        public int Id { get; set; }
        public decimal NumberPhone { get; set; }
        public string Email { get; set; }
        public string PassWordShop { get; set; }
        public string NameShop { get; set; }
        public string LinkShop { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }

    }
}
