using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.Const
{
    public static class MessageOutput
    {
        /// <summary>
        /// Không được để trống
        /// </summary>
        public const string NOT_NULL = "Can't leave null";

        /// <summary>
        /// Vui lòng nhập giá trị lớn hơn
        /// </summary>
        public const string ENTER_VALUE_BIGGER_THAN = "Please enter a value bigger than {1}";

        /// <summary>
        /// Vui lòng nhập kích thước trang lớn hơn ...
        /// </summary>
        public const string PAGE_SIZE_BIGGER_THAN = "Please enter a page size bigger than {1}";

        /// <summary>
        /// Vui lòng nhập kích thước trang lớn hơn ...
        /// </summary>
        public const string PAGE_INDEX_BIGGER_THAN = "Please enter a page index bigger than {1}";

        /// <summary>
        /// Category không tồn tại
        /// </summary>
        public const string CATEGORY_NOT_EXISTS = "CATEGORY_NOT_EXISTS";

        /// <summary>
        /// Khoog thê insert spec
        /// </summary>
        public const string SPECIFICATION_ATTRIBUTE_NOT_INSERT = "SPECIFICATION_ATTRIBUTE_NOT_INSERT";

        /// <summary>
        /// Tham số không hợp lệ 
        /// </summary>
        public const string INVALID_PARAMETER = "INVALID_PARAMETER";

        /// <summary>
        /// Tham số truyền vào đã tồn tại
        /// </summary>
        public const string EXISTS_PARAMETER = "EXISTS_PARAMETER";

        /// <summary>
        /// độ dài chuỗi quá lớn
        /// </summary>
        public const string MAX_LENGTH = "MAX_LENGTH";
    }
}
