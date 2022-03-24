using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.Base;

namespace Product.API.SettingUrl.AlbumRouter
{
    public class UploadRouter
    {
        public static class Avatar
        {
            private const string URL = "/upload-avatar";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }
        public static class Icon
        {
            private const string URL = "/upload-icon";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }

        public static class Product
        {
            private const string URL = "/upload-product";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }

        public static class Post
        {
            private const string URL = "/upload-post";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }

        public static class Root
        {
            private const string URL = "/upload-root";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }

        public static class NameDefault
        {
            private const string URL = "/name-avatar-default";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }
    }
}
