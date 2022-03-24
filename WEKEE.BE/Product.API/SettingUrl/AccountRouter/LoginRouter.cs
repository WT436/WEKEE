using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.Base;

namespace Product.API.SettingUrl.AccountRouter
{
    public static class LoginRouter
    {
        /// <summary>đổi mật khẩu</summary>
        public const string ChangePassword = RootUrl.ROOT + "/account-change-password";
        /// <summary>Quên mật khẩu</summary>
        public const string ForgotPassword = RootUrl.ROOT + "/account-forgot-password";      
        /// <summary>Đăng nhập</summary>
        public const string LoginAccount = RootUrl.ROOT + "/account-log-in";       
        /// <summary>đăng nhập v2</summary>
        public const string LoginAuthv2 = RootUrl.ROOT + "/account-log-in-Auth-v2";
        /// <summary>đăng ký</summary>
        public const string Registration = RootUrl.ROOT + "/account-registration";
    }
}
