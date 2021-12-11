
using Account.Domain.BoundedContext;
using Account.Domain.CoreDomain;
using Account.Domain.Dto;
using Account.Domain.Entitys;
using Account.Infrastructure.ModelQuery;
using System;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.ForgotPassword
{
    public class AForgotPassword : IForgotPassword
    {
        private readonly CheckAccountDomain checkAccountDomain = new CheckAccountDomain();
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly UserAccountIpQuery userAccountIpQuery = new UserAccountIpQuery();
        private readonly CheckStatusAccount checkStatusAccount = new CheckStatusAccount();
        private readonly UserAccountStatusQuery userAccountStatusQuery = new UserAccountStatusQuery();
        private readonly CheckStatusCode checkStatusCode = new CheckStatusCode();
        private readonly UpdateParameter updateParameter = new UpdateParameter();
        public bool TokenRequest(ForgotPasswordDtos forgotPasswordDtos, string ip)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> TokenRequestAsync(ForgotPasswordDtos forgotPasswordDtos, string ip)
        {
            checkAccountDomain.CheckAccount(forgotPasswordDtos.Account);
            checkAccountDomain.CheckEmail(forgotPasswordDtos.Email);

            var accountDb = await userAccountQuery.GetAllAccount(forgotPasswordDtos.Account);

            if (accountDb == null)
            {
                throw new ClientException(400, "Invalid-Account!");
            }

            if (forgotPasswordDtos.Email != null && accountDb.Email != forgotPasswordDtos.Email)
            {
                throw new ClientException(400, "This-email-is-not-yours!");
            }
            // kiểm tra ip .nếu như có ip thì có thể gửi token hoặc số điện thoại. nếu không thì chỉ gửi token
            var listUserAccountIp = await userAccountIpQuery.GetListIpWithAccountAsync(accountDb.Id);
            var accountStatus = await userAccountStatusQuery.GetStatusWithId(accountDb.Id);
            if (checkStatusAccount.CheckExistsIpAccount(listUserAccountIp, ip))
            {
                // kiểm tra tồn tại token cũ 
                if (checkStatusCode.CheckPerformance(accountStatus))
                {
                    _ = updateParameter.UpdateAccountStatus(accountStatus);
                }
                else
                {
                    // tyao moi token bắt buộc xác thực
                }
            }
            else
            {
                if (checkStatusCode.CheckPerformance(accountStatus))
                {
                    // gui lai token
                }
            }
            return true;

        }
        public bool TokenRequestConfirmation(ForgotPasswordConfirmationCodeDtos forgotPasswordConfirmationCodeDtos, string ip)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> TokenRequestConfirmationAsync(ForgotPasswordConfirmationCodeDtos forgotPasswordConfirmationCodeDtos, string ip)
        {
            throw new NotImplementedException();
        }
        public bool TokenRequestConfirmationUrl(ForgotPasswordConfirmationTokenDtos forgotPasswordConfirmationTokenDtos, string ip)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> TokenRequestConfirmationUrlAsync(ForgotPasswordConfirmationTokenDtos forgotPasswordConfirmationTokenDtos, string ip)
        {
            throw new NotImplementedException();
        }              
        public bool CodeRequest(ForgotPasswordDtos forgotPasswordDtos, string ip)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CodeRequestAsync(ForgotPasswordDtos forgotPasswordDtos, string ip)
        {
            throw new NotImplementedException();
        }

    }
}
