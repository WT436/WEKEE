using Account.Domain.Shared.DataTransfer.IPDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IProcessIPClient
    {
        Task<IpReadDto> GetIpClient();
        Task<IpReadDto> ProcessIpClient();
    }
}
