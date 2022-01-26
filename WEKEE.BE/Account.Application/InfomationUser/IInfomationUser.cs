using Account.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.InfomationUser
{
    public interface IInfomationUser
    {
        Task<UserAccountDtos> GetBasicAccount(int id);
    }
}
