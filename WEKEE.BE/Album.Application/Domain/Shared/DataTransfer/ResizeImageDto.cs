using System.Collections.Generic;

namespace Album.Application.Domain.Shared.DataTransfer
{
    public class ResizeImageDto : BasicImage
    {
        public SizeImageDto ListSizeImages { get; set; }
    }
}
