using System;
using System.Collections.Generic;
using System.Text;
using Utils.Any;
using Utils.Exceptions;

namespace Product.Domain.BoundedContext
{
    public static class CheckData
    {
        public static void CheckSpecial(string input)
        {
            if (RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, input))
            {
                throw new ClientException(400, "Data must not contain special characters");
            }
        }
    }
}
