using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IUserProfileAdmin
    {
        Task<List<UserProfileCompactReadDto>> GetCompactUserProfile(SearchTextInput input);
    }
}
