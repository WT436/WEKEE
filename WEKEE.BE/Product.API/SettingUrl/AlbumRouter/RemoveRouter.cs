using Product.API.SettingUrl.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.SettingUrl.AlbumRouter
{
    public class RemoveRouter
    {
        public static class RemoveImage
        {
            private const string URL = "/remove-image";
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
        }
    }
}
