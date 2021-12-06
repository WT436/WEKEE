using System;
using System.Collections.Generic;
using System.Text;
using Utils.Any;
using Utils.Exceptions;

namespace Product.Domain.BoundedContext
{
    public class CheckProduct
    {
        public void CheckName(string name)
        {
            bool isSpecial = RegexProcess.Regex_IsMatch(RegexProcess.SPECIAL_CHAR, name);
            bool isMax100 = name.Length > 5 && name.Length < 100;
            if (isSpecial || !isMax100)
            {
                throw new ClientException(400, "Data must not contain special characters");
            }
        }

        public void CheckOrigin(string origin)
        {
            if (origin.Length > 300 || origin.Length < 1)
            {
                throw new ClientException(400, "The number of Adresses is too large or empty!");
            }
        }

        public void CheckTag(string tag)
        {
            if (tag.Length > 300 || tag.Length < 1)
            {
                throw new ClientException(400, "The number of tags is too large or empty!");
            }
        }
    }
}
