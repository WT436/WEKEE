using Album.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Domain.BoundedContext
{
    public static class ConfigSizeImage
    {
        public static SizeImage ReturnSizeDefault(ObjectValues.SizeImage sizeImage)
        {
            return sizeImage switch
            {
                ObjectValues.SizeImage.S120x120 => new SizeImage { MaxWidth = 120, MaxHeight = 120 },
                ObjectValues.SizeImage.S300x400 => new SizeImage { MaxWidth = 300, MaxHeight = 400 },
                ObjectValues.SizeImage.S600x800 => new SizeImage { MaxWidth = 600, MaxHeight = 800 },
                ObjectValues.SizeImage.S800x500 => new SizeImage { MaxWidth = 800, MaxHeight = 500 },
                ObjectValues.SizeImage.S300x188 => new SizeImage { MaxWidth = 300, MaxHeight = 188 },
                ObjectValues.SizeImage.S1360x540 => new SizeImage { MaxWidth = 1360, MaxHeight = 540 },
                ObjectValues.SizeImage.S300x300 => new SizeImage { MaxWidth = 300, MaxHeight = 300 },
                ObjectValues.SizeImage.S640x360 => new SizeImage { MaxWidth = 640, MaxHeight = 360 },
                ObjectValues.SizeImage.S180x180 => new SizeImage { MaxWidth = 180, MaxHeight = 180 },
                ObjectValues.SizeImage.S340x340 => new SizeImage { MaxWidth = 340, MaxHeight = 340 },
                ObjectValues.SizeImage.S80x80 => new SizeImage { MaxWidth = 80, MaxHeight = 80 },
                ObjectValues.SizeImage.S220x220 => new SizeImage { MaxWidth = 220, MaxHeight = 220 },
                _ => throw new NotImplementedException()
            };
        }

        public static string NameSizeDefault(ObjectValues.SizeImage sizeImage)
        {
            return sizeImage switch
            {
                ObjectValues.SizeImage.S120x120 => "S120x120",
                ObjectValues.SizeImage.S300x400 => "S300x400",
                ObjectValues.SizeImage.S600x800 => "S600x800",
                ObjectValues.SizeImage.S800x500 => "S800x500",
                ObjectValues.SizeImage.S300x188 => "S300x188",
                ObjectValues.SizeImage.S1360x540=> "S1360x540",
                ObjectValues.SizeImage.S300x300 => "S300x300",
                ObjectValues.SizeImage.S640x360 => "S640x360",
                ObjectValues.SizeImage.S180x180 => "S180x180",
                ObjectValues.SizeImage.S340x340 => "S340x340",
                ObjectValues.SizeImage.S80x80 => "S80x80",
                ObjectValues.SizeImage.S220x220 => "S220x220",
                _ => throw new NotImplementedException()
            };
        }
    }
}
