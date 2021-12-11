using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Enum
{
    public class OrderByPageListInput : PagedListInput
    {
        /// <summary>Tên trường sắp xếp</summary>
        public string Property { get; set; }
        /// <summary>Sắp xếp</summary>
        public string OrderBy { get; set; }
    }
}
