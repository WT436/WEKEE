using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.ConstProperty
{
    public static class OrderByProperty
    {
        public const string UP = "Id";
        public const string DOWN = "NameCategory";

        public static string CONVERT_ORDER_BY(string key)
        {
            return key switch
            {
                UP => "ASC",
                DOWN => "DESC",
                _ => "ASC",
            };
        }
    }
}
