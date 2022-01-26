
using Account.Domain.Shared.DataTransfer;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.InfomationUser
{
    public class AInfomationUser : IInfomationUser
    {
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly InfomationUserQuery infomationUserQuery = new InfomationUserQuery();
        private readonly UserProfileQuery userProfileQuery = new UserProfileQuery();
        public async Task<UserAccountDtos> GetBasicAccount(int id)
        {
            var fullAccount = await userAccountQuery.GetAccountInIdAsync(id);
            var infoUser = await infomationUserQuery.GetUniqueAsync(fullAccount.Id);
            var profileUser = await userProfileQuery.GetUniqueId(fullAccount.Id);
            var data = MappingData.InitializeAutomapper().Map<UserAccountDtos>(fullAccount);
            data.Picture = infoUser.Picture;
            return data;
        }
    }
}
