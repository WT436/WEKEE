using Album.Domain.ObjectValues;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Album.Domain.BoundedContext
{
    public static class OpenImage
    {
        public static async Task<Bitmap> ConvertIFormFileToBitmap(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return new Bitmap(Image.FromStream(memoryStream));
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
