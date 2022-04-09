using Album.Application.Domain.ObjectValues;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static Album.Application.Domain.ObjectValues.FolderSaveExtensions;

namespace Album.Application.Domain.BoundedContext
{
    public static class OpenImage
    {


        public static async Task<Bitmap> ConvertIFormFileToBitmap(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var image = Image.FromStream(memoryStream);
            Bitmap bitmap = new Bitmap(image);
            image.Save(memoryStream, ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return bitmap;
        }

        public static Bitmap ConvertIFormFileToBitmap(string nameFile, FolderSave folderSave)
        {
            string path = Path.GetFullPath(
                          Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\album\{FolderSaveConvert(folderSave)}\"));
            string fillPath = path + nameFile;
            if (File.Exists(fillPath) && ImageExtensions.Contains(Path.GetExtension(fillPath).ToLower()))
            {
                var bitmap = new Bitmap(fillPath);
                return bitmap;
            }
            else
            {
                return null;
            }
        }

        public static Task<Bitmap> TransparentAsync(this Bitmap image, Color color, int tolerance) =>
           Task.Run(() => image.Transparent(color, tolerance));

        public static Bitmap Transparent(this Bitmap image, Color color, int tolerance)
        {
            Bitmap b = new Bitmap(image);

            b.ForEachPixel((i, j, col) =>
            {
                if (col.IsCloseTo(color, tolerance))
                    b.SetPixel(i, j, color);
            });

            b.MakeTransparent(color);

            return b;
        }

        public static bool IsCloseTo(this Color color, Color anotherColor, int tolerance)
        {
            return Math.Abs(color.R - anotherColor.R) < tolerance &&
                   Math.Abs(color.G - anotherColor.G) < tolerance &&
                   Math.Abs(color.B - anotherColor.B) < tolerance;
        }

        public static void ForEachPixel(this Bitmap image, Action<int, int, Color> onPixel)
        {
            for (int i = image.Size.Width - 1; i >= 0; i--)
            {
                for (int j = image.Size.Height - 1; j >= 0; j--)
                {
                    onPixel(i, j, image.GetPixel(i, j));
                }
            }
        }

        private static readonly List<string> ImageExtensions = new List<string>
        {
            ExtensionType.JPG,
            ExtensionType.JPE,
            ExtensionType.BMP,
            ExtensionType.GIF,
            ExtensionType.PNG
        };

        public static async Task<Image> OpenImageAsync(string url)
        {
            string path = Path.GetFullPath(
                           Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\"));
            string fillPath = path + url;
            if (File.Exists(fillPath) && ImageExtensions.Contains(Path.GetExtension(fillPath).ToUpperInvariant()))
            {
                var bitmap = new Bitmap(fillPath);
                return bitmap;
            }
            else
            {
                return null;
            }
        }
    }
}
