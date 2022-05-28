
using Account.Domain.Shared.DataTransfer.IPDTO;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Service
{
    public interface IProcessIPClient
    {
        Task<IpReadDto> GetIpClient();
        Task<IpReadDto> ProcessIpClient();
    }
    public class ProcessIPClientService : IProcessIPClient
    {
        public async Task<IpReadDto> GetIpClient()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            List<string> IpV4 = new List<string>();
            List<string> IpV6 = new List<string>();
            foreach (var ip in host.AddressList)
            {
                // var is_v4 = RegexProcess.Regex_IsMatch(RegexProcess.CHECK_IP_V4, ip.ToString());
                // var is_v6 = RegexProcess.Regex_IsMatch(RegexProcess.CHECK_IP_V6, ip.ToString());
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IpV4.Add(ip.ToString());
                }

                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    IpV6.Add(ip.ToString());
                }
            };

            return new IpReadDto { IpV4 = IpV4, IpV6 = IpV6 };
        }

        public async Task<IpReadDto> ProcessIpClient()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string IpV4 = string.Empty;
            string IpV6 = string.Empty;
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IpV4 = IpV4 + ip.ToString() + "|";
                }

                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    IpV6 = IpV6 + ip.ToString() + "|";
                }
            };

            return new IpReadDto { IpV4String = IpV4, IpV6String = IpV6 };
        }
    }
}
