using Account.API.SettingUrl.Base;

namespace Account.API.SettingUrl.AdminRouter
{
    public class AdminRouter
    {
        /// <summary>trình điểu khiển tài khoản</summary>
        public static class Home
        {
            private const string URL = "/admin-home";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
            public const string GET = RootUrl.ROOT + Base.ActionRouter.GET + URL;
        }
        /// <summary>Quyền tài khoản</summary>
        public static class Role
        {
            private const string URL = "/admin-role";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
            public const string GET = RootUrl.ROOT + Base.ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + Base.ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + Base.ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + Base.ActionRouter.UPDATE + URL;
            public const string CREATE = RootUrl.ROOT + Base.ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + Base.ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + Base.ActionRouter.EDIT + URL;
        }
        public static class AdminProcessAccount
        {
            private const string URL = "/admin-process-account";
            public const string WATCH = RootUrl.ROOT + Base.ActionRouter.WATCH + URL;
            public const string GET = RootUrl.ROOT + Base.ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + Base.ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + Base.ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + Base.ActionRouter.UPDATE + URL;
            public const string CREATE = RootUrl.ROOT + Base.ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + Base.ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + Base.ActionRouter.EDIT + URL;
        }

        public static class AdminUploadImageAccount
        {
            private const string URL = "/admin-Upload-Image-Account";
            public const string PATCH = RootUrl.ROOT + Base.ActionRouter.PATCH + URL;
        }

        public static class AdminAccount
        {
            private const string URL = "/admin-account";
            public const string LIST = RootUrl.ROOT + Base.ActionRouter.LIST + URL;
            public const string DELETE = RootUrl.ROOT + Base.ActionRouter.DELETE + URL;
            public const string UPDATE = RootUrl.ROOT + Base.ActionRouter.UPDATE + URL;
            public const string EDIT = RootUrl.ROOT + Base.ActionRouter.EDIT + URL;
        }

        public static class AdminAccountProcessList
        {
            private const string URL = "/admin-account-process-list";
            public const string LIST = RootUrl.ROOT + Base.ActionRouter.LIST + URL;
            public const string DELETE = RootUrl.ROOT + Base.ActionRouter.DELETE + URL;
            public const string UPDATE = RootUrl.ROOT + Base.ActionRouter.UPDATE + URL;
            public const string EDIT = RootUrl.ROOT + Base.ActionRouter.EDIT + URL;
        }
    }
}
