using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Domain.Dtos
{
    public class CutImageDtos : ResizeImageDto
    {
        public List<Point> Points { get; set; }
    }
}
