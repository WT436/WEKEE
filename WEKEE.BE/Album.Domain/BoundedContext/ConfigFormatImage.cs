using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Album.Domain.BoundedContext
{
    public static class ConfigFormatImage
    {
        public static ImageFormat GetImageFormat(ObjectValues.FormatImage formatImage)
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
   
        public static string SetNameFormat(ObjectValues.FormatImage formatImage)
        {
            return formatImage switch
            {
                ObjectValues.FormatImage.JPEG_JPG => ".jpg",
                ObjectValues.FormatImage.PNG =>".png",
                ObjectValues.FormatImage.GIF => ".gif",
                ObjectValues.FormatImage.Emf => ".emf",
                ObjectValues.FormatImage.Exif =>".exif",
                ObjectValues.FormatImage.Icon =>".icon",
                ObjectValues.FormatImage.Tiff =>".tiff",
                ObjectValues.FormatImage.Wmf => ".wmf",
                _ => ".jpg"
            };
        }
    }
}
