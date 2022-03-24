
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.ModelQuery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Application.ProcessIPAccount
{
    public class ProcessIPAccountService : IProcessIPAccount
    {
        private readonly UserAccountIpQuery userAccountIpQuery = new UserAccountIpQuery();
        public IList<UserAccountIp> GetListIPAccount(int id_User)
        {
           return userAccountIpQuery.GetListIpWithAccount(id_User);
        }

        public async Task<IList<UserAccountIp>> GetListIPAccountAsync(int id_User)
        {
            return await userAccountIpQuery.GetListIpWithAccountAsync(id_User);
        }
    }
}
