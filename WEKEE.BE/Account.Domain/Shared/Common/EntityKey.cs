using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Account.Domain.Shared.Common
{
    public class EntityKey<T>
    {
        [Required]
        public T Id { get; set; }
    }
}
