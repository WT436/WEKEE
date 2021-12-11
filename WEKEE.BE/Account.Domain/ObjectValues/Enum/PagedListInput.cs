using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Enum
{
    /// <summary>Phân trang</summary>
    public class PagedListInput
    {
        /// <summary>Số bản ghi trang hiện tại</summary>
        private int pageSize;
        public int PageIndex { get; set; }
        public int PageSize { get => pageSize; set => pageSize = value == 0 ? 20 : value; }
    }
}
