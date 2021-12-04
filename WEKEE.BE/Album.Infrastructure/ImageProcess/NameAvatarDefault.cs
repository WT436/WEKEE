using Album.Domain.BoundedContext;
using Album.Domain.ObjectValues;
using Album.Domain.ServicesDomain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Album.Infrastructure.ImageProcess
{
    public static class NameAvatarDefault
    {
        public static string GenerateAvtarImage(string text)
        {
            text = text.LastIndexOf(" ") == -1 ? text : text[text.LastIndexOf(" ")..].Trim();
            Random rnd = new Random();
            int X = 70;
            int size = 25;
            int Y = 25;
            if (text.Length == 1) { X = 45; Y = 60; size = 45; }
            if (text.Length == 2) { X = 40; Y = 55; size = 45; }
            if (text.Length == 3) { X = 15; size = 55; Y = 50; }
            if (text.Length == 4) { X = 15; size = 40; Y = 55; }
            if (text.Length == 5) { X = 15; size = 35; Y = 60; }
            if (text.Length == 6) { X = 10; size = 30; Y = 65; }
            Font font = new Font(FontFamily.GenericMonospace, size, FontStyle.Bold);
            using (Image img = new Bitmap(180, 180))
            {
                using (Graphics drawing = Graphics.FromImage(img))
                {
                    ConfigGraphics.QuatityImaging(drawing, ConfigImaging.High);
                    SizeF textSize = drawing.MeasureString(text, font);
                    drawing.Clear(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                    using (Brush textBrush = new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))))
                    {
                        drawing.DrawString(text, font, textBrush, new Rectangle(X, Y, 180, 180));
                        drawing.Save();
                    }
                }
                string path = Path.GetFullPath(
                         Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\"));
                int level=-1;
                string nameFile;
                string pathtest;
                do
                {
                    level++;
                    nameFile = NameImage.NameProcessConvert(text: null, level: level);
                    pathtest = path + @"album\avatar\" + nameFile +".jpg";
                } while (File.Exists(pathtest));
                img.Save(pathtest, ConfigFormatImage.GetImageFormat(formatImage: Domain.ObjectValues.FormatImage.JPEG_JPG));
                return nameFile + ".jpg";
            }
        }
    }
}
