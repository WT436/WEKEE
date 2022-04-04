using Album.Application.Domain.ObjectValues;
using Album.Application.Domain.Shared.DataTransfer;
using System;
using System.Drawing;
using Size = System.Drawing.Size;

namespace Album.Application.Infrastructure.ImageProcess
{
    public static class ResizeImage
    {
        public static Image ResizeKeepStruct(ResizeImageDto data)
        {
            #region Ảnh theo kích thước truyền vào và giữ nguyên cấu trúc ảnh
            var ratioX = (double)data.ListSizeImages.MaxWidth / data.Image.Width;
            var ratioY = (double)data.ListSizeImages.MaxHeight / data.Image.Height;
            var ratioNow = Math.Min(ratioX, ratioY);
            int newWidth = (int)(data.Image.Width * ratioNow);
            int newHeight = (int)(data.Image.Height * ratioNow);

            var newImage = new Bitmap(newWidth, newHeight);
            using (Graphics thumbGraph = Graphics.FromImage(newImage))
            {
                ConfigGraphics.QuatityImaging(thumbGraph, data.Quality);
                thumbGraph.DrawImage(data.Image, 0, 0, newWidth, newHeight);
            }
            return newImage;
            #endregion
        }

        public static Image ResizeNotKeepStruct(ResizeImageDto data)
        {
            #region Ảnh theo kích thước truyền vào và ko giữ nguyên cấu trúc ảnh
            var ratioX = (double)data.ListSizeImages.MaxWidth / data.Image.Width;
            var ratioY = (double)data.ListSizeImages.MaxHeight / data.Image.Height;
            int newWidth = (int)(data.Image.Width * ratioX);
            int newHeight = (int)(data.Image.Height * ratioY);

            var newImage = new Bitmap(newWidth, newHeight);
            using (Graphics thumbGraph = Graphics.FromImage(newImage))
            {
                ConfigGraphics.QuatityImaging(thumbGraph,data.Quality);
                thumbGraph.DrawImage(data.Image, 0, 0, newWidth, newHeight);
            }
            return newImage;
            #endregion
        }

        public static Image ResizeImageV2(Image Imagen, int maxWidth, int MaxHeight)
        {
            Image resizedimage = Imagen;

            double calculateWith = (double)maxWidth / (double)resizedimage.Width;
            double calculateHeight = (double)MaxHeight / (double)resizedimage.Height;

            if (((double)maxWidth / (double)Imagen.Width) < ((double)MaxHeight / (double)Imagen.Height))
                resizedimage = (Image)(new Bitmap((Bitmap)resizedimage,
                                       new Size((int)(calculateWith * (double)resizedimage.Width), (int)( calculateWith * (double)resizedimage.Height))));
            else
                resizedimage = (Image)(new Bitmap((Bitmap)resizedimage, 
                                       new Size((int)(calculateHeight * (double)resizedimage.Width), (int)(calculateHeight * (double)resizedimage.Height))));
            return resizedimage;
        }
    }
}
