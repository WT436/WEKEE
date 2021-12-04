using Account.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IInfomationUser
    {
        Task<UserAccountDtos> GetBasicAccount(int id);
    }
}
