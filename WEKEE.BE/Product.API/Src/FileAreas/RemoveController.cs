using Album.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.API.SettingUrl.AlbumRouter;

namespace Product.API.Src.FileAreas
{
    public class RemoveController : Controller
    {
        private readonly IRemoveImage _removeImage;
        public RemoveController(IRemoveImage removeImage)
        {
            _removeImage = removeImage;
        }
        [Route(RemoveRouter.RemoveImage.PATCH)]
        [HttpGet]
        public IActionResult Index(string input)
        {
            _removeImage.RemoveBasic(text: input);
            return Ok("true");
        }
    }
}
