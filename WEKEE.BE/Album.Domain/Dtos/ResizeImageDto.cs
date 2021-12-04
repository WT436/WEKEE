using System.Collections.Generic;

namespace Album.Domain.Dtos
{
    public class ResizeImageDto : BasicImage
    {
        public SizeImage ListSizeImages { get; set; }
    }
}
