using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IUserAccount
    {
        public Task<bool> RegistrationAccount(UserProfileInsertDto input,string IpV4, string IpV6);
    }
}
