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
        public static class ChangePassword
        {
            private const string URL = "/change-password";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
            public const string UPDATE = RootUrl.ROOT + Base.ActionRouter.UPDATE + URL;
        }
        /// <summary>Quên mật khẩu</summary>
        public static class ForgotPassword
        {
            private const string URL = "/forgot-password";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
            public const string GET = RootUrl.ROOT + Base.ActionRouter.GET + URL;
        }
        /// <summary>Đăng nhập</summary>
        public static class LoginAccount
        {
            private const string URL = "/log-in";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
            public const string GET = RootUrl.ROOT + Base.ActionRouter.GET + URL;
        }
        /// <summary>đăng nhập v2</summary>
        public static class LoginAuthv2
        {
            private const string URL = "/log-in-Auth-v2";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
        }
        /// <summary>đăng ký</summary>
        public static class Registration
        {
            private const string URL = "/registration";
            public const string CREATE = RootUrl.ROOT + Base.ActionRouter.CREATE + URL;
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
        }
    }
}
