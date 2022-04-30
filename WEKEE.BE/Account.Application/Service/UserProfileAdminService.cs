using Account.Application.Interface;
using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Account.Infrastructure.ADOQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Service
{
    public class UserProfileAdminService : IUserProfileAdmin
    {
        private readonly UserProfileADO _userProfileADO = new UserProfileADO();
        public async Task<List<UserProfileCompactReadDto>> GetCompactUserProfile(SearchTextInput input)
        {
            return await _userProfileADO.GetCompact(input: input);
        }
    }
}
