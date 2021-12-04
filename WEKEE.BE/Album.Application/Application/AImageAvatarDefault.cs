using Album.Application.Interface;
using Album.Infrastructure.ImageProcess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Application.Application
{
    public class AImageAvatarDefault : IImageAvatarDefault
    {
        public string CreateAvatarDefault(string text)
        {
            NameAvatarDefault.GenerateAvtarImage(text);
            return "";
        }
    }
}
