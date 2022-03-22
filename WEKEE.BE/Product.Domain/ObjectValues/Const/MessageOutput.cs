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
    }
}
