using Album.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Domain.ObjectValues
{
    public enum SizeImage
    {
        S120x120 = 0,
        S300x400 = 1,
        S600x800 = 2,
        S800x500 = 3,
        S300x188 = 4,
        S1360x540 = 5,
        S300x300 = 6,
        S640x360 = 7,
        S180x180 = 8,
        S340x340 = 9,
        S80x80 = 10,
        S220x220 = 11
    }

    public static class ConfigSizeImage
    {
        public static SizeImageDto ReturnSizeDefault(SizeImage sizeImage)
        {
            return sizeImage switch
            {
                SizeImage.S120x120 => new SizeImageDto { MaxWidth = 120, MaxHeight = 120 },
                SizeImage.S300x400 => new SizeImageDto { MaxWidth = 300, MaxHeight = 400 },
                SizeImage.S600x800 => new SizeImageDto { MaxWidth = 600, MaxHeight = 800 },
                SizeImage.S800x500 => new SizeImageDto { MaxWidth = 800, MaxHeight = 500 },
                SizeImage.S300x188 => new SizeImageDto { MaxWidth = 300, MaxHeight = 188 },
                SizeImage.S1360x540 => new SizeImageDto { MaxWidth = 1360, MaxHeight = 540 },
                SizeImage.S300x300 => new SizeImageDto { MaxWidth = 300, MaxHeight = 300 },
                SizeImage.S640x360 => new SizeImageDto { MaxWidth = 640, MaxHeight = 360 },
                SizeImage.S180x180 => new SizeImageDto { MaxWidth = 180, MaxHeight = 180 },
                SizeImage.S340x340 => new SizeImageDto { MaxWidth = 340, MaxHeight = 340 },
                SizeImage.S80x80 => new SizeImageDto { MaxWidth = 80, MaxHeight = 80 },
                SizeImage.S220x220 => new SizeImageDto { MaxWidth = 220, MaxHeight = 220 },
                _ => throw new NotImplementedException()
            };
        }

        public static string NameSizeDefault(SizeImage sizeImage)
        {
            return sizeImage switch
            {
                SizeImage.S120x120 => "S120x120",
                SizeImage.S300x400 => "S300x400",
                SizeImage.S600x800 => "S600x800",
                SizeImage.S800x500 => "S800x500",
                SizeImage.S300x188 => "S300x188",
                SizeImage.S1360x540 => "S1360x540",
                SizeImage.S300x300 => "S300x300",
                SizeImage.S640x360 => "S640x360",
                SizeImage.S180x180 => "S180x180",
                SizeImage.S340x340 => "S340x340",
                SizeImage.S80x80 => "S80x80",
                SizeImage.S220x220 => "S220x220",
                _ => throw new NotImplementedException()
            };
        }
    }
}
