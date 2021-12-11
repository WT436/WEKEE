using Album.Domain.ServicesDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Domain.BoundedContext
{
    public static class NameImage
    {
        private static string NameDefault()
                   => Guid.NewGuid().ToString();

        private static string ConvertNameFolder(string text)
                  => ProcessName.ReplaceWhiteSpace(ProcessName.ConvertVietNamese(text));

        public static string NameProcessConvert(string text, int level)
        {
            text = text?[(text.LastIndexOf("\\") + 1)..text.LastIndexOf(".")];
            string nameApp = "Account-";
            string CreatedAt = $"-{DateTime.Now.ToString("HHmmss-ddMMyyyy")}-";
            string nameLevel = level == 0 ? "" : $"({level})";

            return string.IsNullOrEmpty(text)
                   ? nameApp + NameDefault() + CreatedAt + nameLevel
                   : nameApp + ConvertNameFolder(text) + CreatedAt + nameLevel;
        }
    }
}
