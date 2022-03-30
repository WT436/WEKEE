using Album.Application.Controll.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Src.FileAreas
{
    public class WatchController : Controller
    {
        private readonly IReadInfoFile _readInfoFile;
        public WatchController(IReadInfoFile readInfoFile)
        {
            _readInfoFile = readInfoFile;
        }
        [HttpGet]
        [Route("v1/api/infomation-file")]
        public async Task<IActionResult> Index(string path)
        {
            _readInfoFile.ReadInfoImage(path);
            return Ok();
        }
    }
}
