using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Domain.ObjectValues
{
    public class InputFileImageBases : InputFileBases
    {
        public bool SingleFile { get; set; }
        public SizeImage SizeImage { get; set; }
    }
}
