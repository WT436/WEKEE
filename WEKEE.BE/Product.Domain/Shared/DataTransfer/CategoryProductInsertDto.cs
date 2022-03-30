using Product.Domain.ObjectValues.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain.Shared.DataTransfer
{
    public class CategoryProductInsertDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public string NameCategory { get; set; }
        [Required(ErrorMessage = MessageOutput.NOT_NULL)]
        public string UrlCategory { get; set; }

        public string IconCategory { get; set; }

        //[Required(ErrorMessage = MessageOutput.NOT_NULL)]
        //[Range(1, int.MaxValue, ErrorMessage = MessageOutput.ENTER_VALUE_BIGGER_THAN)]
        //public int LevelCategory { get; set; }

        public int? CategoryMain { get; set; }
        public bool IsEnabled { get; set; }
    }
}
