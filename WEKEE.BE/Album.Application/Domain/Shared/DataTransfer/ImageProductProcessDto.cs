using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Application.Domain.Shared.DataTransfer
{
    public class ImageProductProcessDto
    {
        public string NameUpload { get; set; }
        public string ImageNameRoot { get; set; }
        public string ImageNameSizeS120x120 { get; set; }
        public string ImageNameSizeS1360x540 { get; set; }
        public string ImageNameSizeS180x180 { get; set; }
        public string ImageNameSizeS80x80 { get; set; }
        public string ImageNameSizeS220x220 { get; set; }
        public string ImageNameSizeS340x340 { get; set; }
    }
}
