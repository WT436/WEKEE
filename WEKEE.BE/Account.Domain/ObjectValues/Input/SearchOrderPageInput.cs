﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Input
{
    public class SearchOrderPageInput: OrderByPageListInput
    {
        /// <summary>Tên trường tìm kiếm</summary>
        public int[] PropertySearch { get; set; }
        /// <summary>Nội dung</summary>
        public string[] ValuesSearch { get; set; }
    }
}
