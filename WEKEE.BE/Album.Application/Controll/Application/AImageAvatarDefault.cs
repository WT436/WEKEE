using Album.Application.Interface;
using Album.Application.Infrastructure.ImageProcess;
using System;
using System.Collections.Generic;
using System.Text;
using Album.Application.Controll.Interface;

namespace Album.Application.Controll.Application
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
