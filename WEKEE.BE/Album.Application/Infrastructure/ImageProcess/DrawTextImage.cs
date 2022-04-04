using Album.Application.Domain.ObjectValues;
using System.Drawing;

namespace Album.Application.Infrastructure.ImageProcess
{
    public class DrawTextImage
    {
        public Image WriteTextOnThePicture(Image image, string text,
                                           string font,int size,
                                           System.Drawing.FontStyle fontStyle, Color color,
                                           int X,int Y)
        {
            Graphics graphicImage = Graphics.FromImage(image);
            ConfigGraphics.QuatityImaging(graphicImage, Domain.ObjectValues.ConfigImaging.Low);
            graphicImage.DrawString(text,
                   new Font(font, size, fontStyle), new SolidBrush(color), new Point(X, Y));
            graphicImage.Dispose();
            return image; 
        }
    }
}
