using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ADOQuery
{
    public class UserProfileADO
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                      new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<List<UserProfileCompactReadDto>> GetCompact(SearchTextInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT R.[id] AS 'Id',R.[userName] AS 'UserName' FROM dbo.[UserProfile] AS R WHERE R.[userName] LIKE N'%{input.Text}%'");
            return await unitOfWork.FromSqlAsync<UserProfileCompactReadDto>(query.ToString());
        }
    }
}
