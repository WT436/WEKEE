using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Aggregate
{
    public class StringValidation
    {
        public bool CheckDefault(string str)
        {
            //check null
            if (String.IsNullOrEmpty(str))
            {
                return false;
            }
            return false;
        }
    }
}
