using Album.Application.Controll.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Album.Application.Controll.Application
{
    public class ReadInfoFileService : IReadInfoFile
    {
        public FileInfo ReadInfoImage(string path)
        {
            FileInfo info = new FileInfo(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\")) + path);
            return info;
        }
    }
}
