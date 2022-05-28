using Supplier.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Supplier.Domain.Shared.DataTransfer
{
    public class StoreSelectDtos : EntityKey<int>
    {
        [MaxLength(12)]
        [Required(ErrorMessage = "001")]
        public string NameStore { get; set; }
        public string NameRole{ get; set; }
        public bool? IsBoss { get; set; }
    }
}
