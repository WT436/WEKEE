using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Input
{
    public class OrderByPageListInput : PagedListInput
    {
        /// <summary>Tên trường sắp xếp</summary>
        public int PropertyOrder { get; set; }
        /// <summary>Sắp xếp</summary>
        public int ValueOrderBy { get; set; }
    }
}
