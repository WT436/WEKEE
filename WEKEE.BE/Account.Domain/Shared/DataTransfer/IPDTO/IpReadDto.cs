using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.IPDTO
{
    public class IpReadDto
    {
        public List<string> IpV4 { get; set; }
        public List<string> IpV6 { get; set; }

        public string IpV4String { get; set; }
        public string IpV6String { get; set; }
    }
}
