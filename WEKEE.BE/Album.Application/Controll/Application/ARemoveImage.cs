using Album.Application.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Album.Application.Controll.Application
{
    public class ARemoveImage : IRemoveImage
    {
        public void RemoveBasic(string text)
        {
            string path = Path.GetFullPath(
                           Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\"));

            if(File.Exists(path+text))
            {
                File.Delete(path + text);
            }
        }
    }
}
