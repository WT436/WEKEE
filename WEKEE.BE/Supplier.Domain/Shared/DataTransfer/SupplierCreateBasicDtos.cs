using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Domain.Shared.DataTransfer
{
    public class SupplierCreateBasicDtos
    {
        public decimal NumberPhone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string PassWordShop { get; set; }
        public string NameShop { get; set; }
        public int IdAccount { get; set; }
    }
}
