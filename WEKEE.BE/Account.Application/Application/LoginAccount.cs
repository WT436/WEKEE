using Account.Application.Interface;
using Account.Domain.CoreDomain;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Threading.Tasks;

namespace Account.Application.Application
{
    public class LoginAccount : ILoginAccount
    {
        private readonly CheckAccountDomain checkAccountDomain = new CheckAccountDomain();
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly ShiningAccount shiningAccount = new ShiningAccount();
        private readonly InfomationUserQuery infomationUserQuery = new InfomationUserQuery();
        private readonly UserProfileQuery userProfileQuery = new UserProfileQuery();

        public UserAccount getUserAccount(int id)
        {
            return userAccountQuery.GetAccountInId(id);
        }

        public Task<UserAccount> getUserAccountAsync(int id)
        {
            return userAccountQuery.GetAccountInIdAsync(id);
        }

        public UserAccount LoginUserAccount(AuthenticationInput loginDto, string ipUser)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccountDtos> LoginUserAccountAsync(AuthenticationInput loginDto, string ipUser)
        {
            // kiểm tra định dạng tài khoản
            checkAccountDomain.CheckAccount(loginDto.Account);
            // lấy dữ liệu theo name account
            var fullAccount = await userAccountQuery.GetAllAccount(loginDto.Account);
            var infoUser = await infomationUserQuery.GetUniqueAsync(fullAccount.UserProfileId);
            var profileUser = await userProfileQuery.GetUniqueId(fullAccount.UserProfileId);
            checkAccountDomain.CheckDataAccount(fullAccount);
            // đánh dấu fail 1 lần tăng lên 1 lần
            userAccountQuery.UpLoginFail(fullAccount);
            // kiểm tra login fail
            userAccountQuery.CheckLoginFail(fullAccount);
            // kiểm tra định dạng tài khoản mật khẩu
            checkAccountDomain.CheckPassWord(loginDto.Password);
            // kiem tra thong tin tai khoan vua tra ve với tài khoản và  mật khẩu
            shiningAccount.CheckPassword(fullAccount, loginDto.Password);
            userAccountQuery.ResertLoginFail(fullAccount);
            var data = MappingData.InitializeAutomapper().Map<UserAccountDtos>(fullAccount);
            data.Picture = infoUser.Picture;
            data.FullName = profileUser.FullName;
            return data;
        }
    }
}