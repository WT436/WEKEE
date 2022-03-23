using Product.Domain.ObjectValues.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Domain.ObjectValues.Input
{
    /// <summary>Phân trang</summary>
    public class PagedListInput
    {
        /// <summary>Số bản ghi trang hiện tại</summary>
        
        private int pageSize;
        [Range(1, int.MaxValue, ErrorMessage = MessageOutput.PAGE_INDEX_BIGGER_THAN)]
        public int PageIndex { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = MessageOutput.PAGE_SIZE_BIGGER_THAN)]
        public int PageSize { get => pageSize; set => pageSize = value == 0 ? 20 : value; }
    }
}
