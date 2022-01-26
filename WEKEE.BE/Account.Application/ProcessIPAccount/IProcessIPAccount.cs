using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Account.Domain.ObjectValues;

namespace Account.Application.ProcessIPAccount
{
    /// <summary>
    /// Sử lý thông tin Ip
    /// </summary>
    public interface IProcessIPAccount
    {
        IList<UserAccountIp> GetListIPAccount(int id_User);
        Task<IList<UserAccountIp>> GetListIPAccountAsync(int id_User);
    }
}
