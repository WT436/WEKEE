using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Enum
{
    public class OrderByPageListInput : PagedListInput
    {
        /// <summary>Tên trường sắp xếp</summary>
        public string PropertyOrder { get; set; }
        /// <summary>Sắp xếp</summary>
        public string ValueOrderBy { get; set; }
    }
}
