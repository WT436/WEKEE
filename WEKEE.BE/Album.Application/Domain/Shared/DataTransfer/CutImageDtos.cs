using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Application.Domain.Shared.DataTransfer
{
    public class CutImageDtos : ResizeImageDto
    {
        public List<Point> Points { get; set; }
    }
}
