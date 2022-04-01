using Product.Domain.ObjectValues.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain.Shared.DataTransfer.ProductAttributeDTO
{
    public class ProductAttributeInsertDto
    {
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        [Range(typeof(int), "0", "5", ErrorMessage = MessageOutput.INVALID_PARAMETER)]      
        public int Types { get; set; }
    }
}
