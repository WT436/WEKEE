using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IUserAccount
    {
        Task<bool> RegistrationAccount(UserProfileInsertDto input, string IpV4, string IpV6);

        Task<AuthenticationResult> LoginAccount(AuthenticationInput input, List<string> IpV4, List<string> IpV6);

        Task<AuthenticationResult> RefreshTokenAccount(string token, List<string> IpV4, List<string> IpV6);

        Task<AuthenticationResult> LoginOAuthV2(AuthenV2ReadDto input, List<string> IpV4, List<string> IpV6);
    }
}
