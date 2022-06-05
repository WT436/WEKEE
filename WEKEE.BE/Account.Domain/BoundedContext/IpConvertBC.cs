using Account.Domain.ObjectValues.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Exceptions;

namespace Account.Domain.BoundedContext
{
    public class IpConvertBC
    {
        private bool IpCheck(string ipRoot, List<string> ipInput)
        {
            return ipInput.Select(m => ipRoot.Contains(m)).ToList().Any(m => m == true);
        }

        public void CheckIp(List<string> IpV4s, List<string> IpV6s, string IpV4, string IpV6)
        {
            // kiểm tra ip
            if (!IpCheck(ipRoot: IpV4, ipInput: IpV4s) || !IpCheck(ipRoot: IpV6, ipInput: IpV6s))
            {
                throw new ClientException(200, ErrorOauth.NOT_IP.ToString());
            }
        }
    }
}
