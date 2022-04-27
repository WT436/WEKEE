using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.ConstProperty
{
    enum OrderByType
    {
        UP = 0,
        DOWN = 1
    }
    public static class OrderByTransform
    {
        public static string CONVERT_SQL(int key)
        {
            return (OrderByType)key switch
            {
                OrderByType.UP => "ASC",
                OrderByType.DOWN => "DESC",
                _ => "ASC",
            };
        }
    }
}
