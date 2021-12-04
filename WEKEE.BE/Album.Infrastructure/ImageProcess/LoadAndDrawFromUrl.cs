

using System.Drawing;
using System.IO;
using System.Net;

namespace Album.Infrastructure.ImageProcess
{
    public class LoadAndDrawFromUrl
    {
        public Image LoadImageWeb(string url)
        {
            WebRequest webreq = WebRequest.Create(url);
            WebResponse webres = webreq.GetResponse();
            Stream stream = webres.GetResponseStream();

            return Image.FromStream(stream);
        }
    }
}
