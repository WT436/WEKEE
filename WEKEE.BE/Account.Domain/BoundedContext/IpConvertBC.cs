using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.Domain.BoundedContext
{
    public static class IpConvertBC
    {
        public static bool IpCheck(string ipRoot, List<string> ipInput)
        {
            return ipInput.Select(m => ipRoot.Contains(m)).ToList().Any(m => m == true);
        }
    }
}
