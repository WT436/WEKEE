using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Application
{
    public class AInfomationUser : IInfomationUser
    {
        private readonly UserAccountQuery userAccountQuery = new UserAccountQuery();
        private readonly InfomationUserQuery infomationUserQuery = new InfomationUserQuery();
        private readonly UserProfileQuery userProfileQuery = new UserProfileQuery();
        public async Task<UserAccountDtos> GetBasicAccount(int id)
        {
            var fullAccount = await userAccountQuery.GetAccountInIdAsync(id);
            var infoUser = await infomationUserQuery.GetUniqueAsync(fullAccount.UserProfileId);
            var profileUser = await userProfileQuery.GetUniqueId(fullAccount.UserProfileId);
            var data = MappingData.InitializeAutomapper().Map<UserAccountDtos>(fullAccount);
            data.Picture = infoUser.Picture;
            data.FullName = profileUser.FullName;
            return data;
        }
    }
}
