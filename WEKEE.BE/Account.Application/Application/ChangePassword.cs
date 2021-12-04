using Account.Application.Interface;
using Account.Domain.CoreDomain;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Infrastructure.ModelQuery;
using System;
using System.Threading.Tasks;

namespace Account.Application.Application
{
    public class ChangePassword : IChangePassword
    {
        private readonly CheckAccountDomain checkAccountDomain = new CheckAccountDomain();
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly ShiningAccount shiningAccount = new ShiningAccount();
        private readonly CheckStatusAccount checkStatusAccount = new CheckStatusAccount();
        private readonly UserAccountIpQuery userAccountIpQuery = new UserAccountIpQuery();

        public bool DefaultChangPass(AuthenticationInput loginDto, string passNew, string ipUser)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DefaultChangPassAsync(AuthenticationInput loginDto, string passNew, string ipUser)
        {
            checkAccountDomain.CheckLoginAccount(loginDto);
            checkAccountDomain.CheckPassWord(passNew);

            var fullAccount = await userAccountQuery.GetAllAccount(loginDto.Account);
            var fullIpUser = await userAccountIpQuery.GetListIpWithAccountAsync(fullAccount.UserProfileId);
            checkStatusAccount.CheckExistsIpAccount(fullIpUser, ipUser);

            await checkStatusAccount.StatusAccount(fullAccount);
            shiningAccount.CheckPassword(fullAccount, loginDto.Password);

            fullAccount.Password = passNew;
            var new_account = shiningAccount.SetupAccount(fullAccount);
            userAccountQuery.UpdateAccount(new_account);

            return true;
        }
    }
}
