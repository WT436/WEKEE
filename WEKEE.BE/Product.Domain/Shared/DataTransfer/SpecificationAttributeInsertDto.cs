using Product.Domain.ObjectValues.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain.Shared.DataTransfer
{
    public class SpecificationAttributeInsertDto
    {
        [MaxLength(200)]
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public string Key { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = MessageOutput.ENTER_VALUE_BIGGER_THAN)]
        public int CategoryProductId { get; set; }
        public string GroupSpecification { get; set; }
    }
}
