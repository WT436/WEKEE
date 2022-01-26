﻿using System.Threading.Tasks;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;

namespace Account.Application.ChangePassword
{
    /// <summary>
    /// Thay đổi mật khẩu
    /// </summary>
    public interface IChangePassword
    {
        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        Task<bool> DefaultChangPassAsync(AuthenticationInput loginDto, string passNew, string ipUser);
        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        bool DefaultChangPass(AuthenticationInput loginDto, string passNew, string ipUser);
    }
}
