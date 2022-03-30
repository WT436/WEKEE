using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Album.Application.Controll.Interface
{
    public interface IReadInfoFile
    {
        FileInfo ReadInfoImage(string path);
    }
}
