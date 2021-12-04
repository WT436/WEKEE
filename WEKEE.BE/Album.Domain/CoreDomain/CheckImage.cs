using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Album.Domain.CoreDomain
{
    public class CheckImage
    {
        /// <summary>
        /// Kiểm tra hình dạng ảnh
        /// <para>0: Hình chữ nhật ngang</para>
        /// <para>1: Hình chữ nhật dọc</para>
        /// <para>2: Hình Vuông</para>
        /// </summary>
        public int CheckShapeImage(Image image)
        {
            if (image.Width > image.Height)
                return 0;
            else if (image.Width < image.Height)
                return 1;
            else
                return 2;
        }

        public bool CheckFile(IFormFile file)
        {
            if (file == null || file.Length == 0)  return false;
            return true;
        }
    }
}
