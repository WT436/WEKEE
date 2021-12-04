using Account.Domain.Dto;
using Account.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IAccountAdminProcess
    {
        /// <summary>
        /// Admin tạo tài khoản hoặc sửa tài khoản
        /// </summary>
        public Task InsertOrUpdateAccount(AccountAdminCreate accountAdminCreate, string ipUser, string userAgent);
    }
}
