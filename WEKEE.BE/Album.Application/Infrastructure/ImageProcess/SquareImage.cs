using Album.Application.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Album.Application.Infrastructure.ImageProcess
{
    public static class SquareImage
    {
        /// <summary>
        /// Chuyển đổi ảnh vuông và ảnh nằm giữa
        /// </summary>
        public static Bitmap ConvertSquareImage(Image imageItem)
        {
            // Lấy cạnh lớn nhất
            var maxEdge = Math.Max(imageItem.Width, imageItem.Height);
            // Tạo bitMap Vuông
            Bitmap newImage = new Bitmap(maxEdge, maxEdge, PixelFormat.Format24bppRgb);

            // cài độ phân giải
            newImage.SetResolution(80, 60);

            using (Graphics gfx = Graphics.FromImage(newImage))
            {
                ConfigGraphics.QuatityImaging(gfx, ConfigImaging.High);
                Brush aBrush = (Brush)Brushes.LightGray;
                // ảnh đang nằm ngang => cho ảnh nằm ngang ở giữa nền hình vuông
                // lấy Width làm cạnh hình vuông
                if (imageItem.Width > imageItem.Height)
                {
                    gfx.FillRectangle(aBrush, 0, 0, imageItem.Width, imageItem.Width);
                    gfx.DrawImage(imageItem,
                                  new Rectangle(0, (imageItem.Width - imageItem.Height) / 2,
                                                imageItem.Width, imageItem.Height),
                                  0, 0, imageItem.Width, imageItem.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    // gán màu nền
                    gfx.FillRectangle(aBrush, 0, 0, imageItem.Height, imageItem.Height);
                    // di chuyển ảnh vào trung tâm
                    gfx.DrawImage(imageItem,
                                  new Rectangle((imageItem.Height - imageItem.Width) / 2, 0,
                                  imageItem.Width, imageItem.Height),
                                  0, 0, imageItem.Width, imageItem.Height, GraphicsUnit.Pixel);
                }
            }
            return newImage;
        }

    }
}
