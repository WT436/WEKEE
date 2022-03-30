using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace Album.Domain.ObjectValues
{
    public enum FormatImage
    {
        JPEG_JPG = 0,
        PNG = 1,
        GIF = 2,
        Emf = 3,
        Exif = 4,
        Icon = 6,
        Tiff = 7,
        Wmf = 8
    }

    public static class ConfigFormatImage
    {
        public static ImageFormat GetImageFormat(FormatImage formatImage)
        {
            return formatImage switch
            {
                ObjectValues.FormatImage.JPEG_JPG => ImageFormat.Jpeg,
                ObjectValues.FormatImage.PNG => ImageFormat.Png,
                ObjectValues.FormatImage.GIF => ImageFormat.Gif,
                ObjectValues.FormatImage.Emf => ImageFormat.Emf,
                ObjectValues.FormatImage.Exif => ImageFormat.Exif,
                ObjectValues.FormatImage.Icon => ImageFormat.Icon,
                ObjectValues.FormatImage.Tiff => ImageFormat.Tiff,
                ObjectValues.FormatImage.Wmf => ImageFormat.Wmf,
                _ => ImageFormat.Jpeg,
            };
        }

        public static string SetNameFormat(FormatImage formatImage)
        {
            return formatImage switch
            {
                ObjectValues.FormatImage.JPEG_JPG => ExtensionType.JPG,
                ObjectValues.FormatImage.PNG => ExtensionType.PNG,
                ObjectValues.FormatImage.GIF => ExtensionType.GIF,
                ObjectValues.FormatImage.Emf => ExtensionType.EMF,
                ObjectValues.FormatImage.Exif => ExtensionType.EXIF,
                ObjectValues.FormatImage.Icon => ExtensionType.ICO,
                ObjectValues.FormatImage.Tiff => ExtensionType.TIFF,
                ObjectValues.FormatImage.Wmf => ExtensionType.WMF,
                _ => ExtensionType.JPG
            };
        }
    }
}
