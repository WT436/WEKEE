using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.UserProfileDTO;
using Account.Domain.Shared.Entitys;
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
        public async Task<List<UserProfile>> GetAccount(string account)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT * FROM dbo.[UserProfile] AS R WHERE R.[userName] LIKE '{account}'");
            return await unitOfWork.FromSqlAsync<UserProfile>(query.ToString());
        }
        public async Task<List<UserProfileCompactReadDto>> GetCompact(SearchTextInput input)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT R.[id] AS 'Id',R.[userName] AS 'UserName' FROM dbo.[UserProfile] AS R WHERE R.[userName] LIKE N'%{input.Text}%'");
            return await unitOfWork.FromSqlAsync<UserProfileCompactReadDto>(query.ToString());
        }

        public async Task<List<UserProfileLoginReadDto>> GetAccountLogin(string account)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"SELECT                                                                           ");
            query.AppendLine($"	   UP.[userName]                                                                ");
            query.AppendLine($"	  ,UP.[email]                                                                   ");
            query.AppendLine($"	  ,UP.[isOnline]                                                                ");
            query.AppendLine($"	  ,UP.[isStatus]                                                                ");
            query.AppendLine($"	  ,UP.[loginFallNumber]                                                         ");
            query.AppendLine($"	  ,UP.[lockAccountTime]                                                         ");
            query.AppendLine($"	  ,UP.[time_zone]                                                               ");
            query.AppendLine($"	  ,UPASS.[Password]                                                             ");
            query.AppendLine($"	  ,UPASS.[PasswordSalt]                                                         ");
            query.AppendLine($"	  ,UPASS.[PasswordHashAlgorithm]                                                ");
            query.AppendLine($"	  ,UI.[ipv4]                                                                    ");
            query.AppendLine($"	  ,UI.[ipv6]                                                                    ");
            query.AppendLine($"	  ,IU.[firsName]                                                                ");
            query.AppendLine($"	  ,IU.[lastName]                                                                ");
            query.AppendLine($"	  ,IU.[picture]                                                                 ");
            query.AppendLine($"	  ,IU.[gender]                                                                  ");
            query.AppendLine($"FROM dbo.[UserProfile] AS UP                                                     ");
            query.AppendLine($"INNER JOIN dbo.[UserPassword] UPASS ON UP.[id] = UPASS.[AccountId]               ");
            query.AppendLine($"INNER JOIN dbo.[UserIp] UI ON UP.[id] = UI.[AccountId]                           ");
            query.AppendLine($"LEFT JOIN dbo.[InfomationUser] IU ON UP.[id] = IU.[AccountId]                    ");
            query.AppendLine($"WHERE UP.[userName] = '{account}'AND UP.[isDelete] = 0 AND UP.[isActive] = 1     ");
            query.AppendLine($"	  AND UPASS.[isActive] =1 AND UPASS.[isDelete] = 0                              ");
            query.AppendLine($"	  AND UI.[isActive] = 1 AND UI.[isDelete] = 0                                   ");
            query.AppendLine($"	  AND IU.[isActive] = 1                                                         ");
            return await unitOfWork.FromSqlAsync<UserProfileLoginReadDto>(query.ToString());
        }
    }
}
