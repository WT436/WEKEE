using Album.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Album.Domain.Dtos
{
    public class BasicImage
    {
        public Image Image { get; set; }
        public string NameReturn { get; set; }
        public ConfigImaging Quality { get; set; } = ConfigImaging.Low;
    }
}
