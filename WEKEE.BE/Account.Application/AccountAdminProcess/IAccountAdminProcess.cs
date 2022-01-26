using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.AccountAdminProcess
{
    public interface IAccountAdminProcess
    {
        /// <summary>
        /// Admin tạo tài khoản hoặc sửa tài khoản
        /// </summary>
        public Task InsertOrUpdateAccount(AccountAdminCreate accountAdminCreate, string ipUser, string userAgent);
    }
}
