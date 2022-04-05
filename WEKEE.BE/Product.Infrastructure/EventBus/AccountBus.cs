using Account.Application.InfomationUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.EventBus
{
    public class AccountBus
    {
        private readonly IInfomationUser _infomationUser = new InfomationUserService();
        public async Task<string> GetNameAccount(int idAccount)
        {
            var data = await _infomationUser.GetNameAccount(id: idAccount);
            return data == null ? "NULL" : data;
        }
    }
}
