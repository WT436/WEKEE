using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Album.Application.Domain.ObjectValues
{
    public class InputFileBases
    {
        public List<IFormFile> Files { get; set; }
        public TypeFile TypeFile { get; set; }
    }
}
