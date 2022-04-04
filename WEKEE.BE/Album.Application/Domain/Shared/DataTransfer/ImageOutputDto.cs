using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Application.Domain.Shared.DataTransfer
{
    public class ImageOutputDto
    {
        public string Name { get; set; }
        public string FolderSave { get; set; }
        public string FormatImage { get; set; }
        public string SizeImages { get; set; }
        public string VirtualPath { get; set; }
    }
}