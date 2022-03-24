using Product.Domain.ObjectValues.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain.Shared.DataTransfer
{
    public class CategoryProductNumberOrderDto
    {
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public int Id { get; set; }

        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        [Range(1, int.MaxValue, ErrorMessage = MessageOutput.ENTER_VALUE_BIGGER_THAN)]
        public int LevelCategory { get; set; }

        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        [Range(1, int.MaxValue, ErrorMessage = MessageOutput.ENTER_VALUE_BIGGER_THAN)]
        public int? CategoryMain { get; set; }

        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        [Range(1, int.MaxValue, ErrorMessage = MessageOutput.ENTER_VALUE_BIGGER_THAN)]
        public int NumberOrder { get; set; }
    }
}
