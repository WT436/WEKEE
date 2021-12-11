using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.Base;

namespace Account.API.SettingUrl.AccountRouter
{
    public static class LoginRouter
    {
        /// <summary>đổi mật khẩu</summary>
        public const string ChangePassword = "/change-password";
        /// <summary>Quên mật khẩu</summary>
        public const string ForgotPassword = "/forgot-password";      
        /// <summary>Đăng nhập</summary>
        public const string LoginAccount = "/log-in";       
        /// <summary>đăng nhập v2</summary>
        public const string LoginAuthv2 = "/log-in-Auth-v2";
        /// <summary>đăng ký</summary>
        public const string Registration = "/registration";
    }
}
