
using Account.Domain.CoreDomain;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.ModelQuery;
using System;
using System.Threading.Tasks;

namespace Account.Application.ChangePassword
{
    public class AChangePassword : IChangePassword
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
            var fullIpUser = await userAccountIpQuery.GetListIpWithAccountAsync(fullAccount.Id);
            checkStatusAccount.CheckExistsIpAccount(fullIpUser, ipUser);

            await checkStatusAccount.StatusAccount(fullAccount);
            shiningAccount.CheckPassword(fullAccount, loginDto.Password);

            fullAccount.Password = passNew;
            var new_account = shiningAccount.SetupAccount(fullAccount);
            userAccountQuery.Update(new_account);

            return true;
        }
    }
}
