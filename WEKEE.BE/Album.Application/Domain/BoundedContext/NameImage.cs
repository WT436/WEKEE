using Album.Application.Domain.ServicesDomain;
using System;

namespace Album.Application.Domain.BoundedContext
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
            string nameLevel = level == 0 ? "" : $"({level})";

            return string.IsNullOrEmpty(text)
                   ? NameDefault() + nameLevel
                   : ConvertNameFolder(text)  + nameLevel;
        }
    }
}
