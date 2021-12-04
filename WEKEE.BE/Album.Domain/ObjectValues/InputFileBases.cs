using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Album.Domain.ObjectValues
{
    public class InputFileBases
    {
        public List<IFormFile> Files { get; set; }
        public TypeFile TypeFile { get; set; }
    }
}
