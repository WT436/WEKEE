using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Domain.Shared.DataTransfer
{
    public class StoreSelectDtos
    {
        public int Id { get; set; }
        public string NameStore { get; set; }
        public string NameRole{ get; set; }
        public bool? IsBoss { get; set; }
    }
}
