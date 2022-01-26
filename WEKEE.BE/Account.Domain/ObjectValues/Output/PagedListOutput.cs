using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Output
{
    /// <summary>Trả về dữ liệu phân trang</summary>
    public class PagedListOutput<T>
    {
        /// <summary>Trang số</summary>
        public int PageIndex { get; set; }
        /// <summary>Số bản ghi trang hiện tại</summary>
        public int PageSize { get; set; }
        /// <summary>Tổng bản ghi</summary>
        public int TotalCount { get; set; }
        /// <summary>Tổng Pages</summary>
        public int TotalPages { get; set; }
        /// <summary>Danh sách dữ liệu</summary>
        public IList<T> Items { get; set; }
    }
}
