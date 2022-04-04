using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Product.API.SettingUrl.AlbumRouter;
using System.Collections.Generic;
using Album.Application.Controll.Interface;
using Album.Application.Domain.ObjectValues;

namespace Product.API.Src.FileAreas
{
    public class UploadController : Controller
    {
        private readonly IImageBasic _imageBasic;
        private readonly IImageAvatarDefault _imageAvatarDefault;
        public UploadController(IImageBasic imageBasic , IImageAvatarDefault imageAvatarDefault)
        {
            _imageBasic = imageBasic;
            _imageAvatarDefault = imageAvatarDefault;
        }

        [Route(UploadRouter.NameDefault.PATCH)]
        [HttpPost]
        public async Task<IActionResult> CreateNameAvatarDefault(string name)
        {
            return Ok(_imageAvatarDefault.CreateAvatarDefault(text: name));
        }

        [Route(UploadRouter.Avatar.PATCH)]
        [HttpPost]
        public async Task<IActionResult> UploadAvatarImage(IFormFile file)
        {
            var url = await _imageBasic.SaveAvatarServer(files: file);
            return Ok(new OutputDefaultFile
            {
                Url = url.Replace("\\", "/")
            }); ;
        }

        [Route("v1/api/upload-icon")]
        [HttpPost]
        public async Task<IActionResult> UploadIconImage(IFormFile file)
        {
            var url = await _imageBasic.SaveIconServer(files: file);
            return Ok(new OutputDefaultFile
            {
                Url = url.Replace("\\", "/")
            }); ;
        }

        [Route(UploadRouter.Product.PATCH)]
        [HttpPost]
        public async Task<IActionResult> UploadProductImage(IFormFile files)
        {
            var url = await _imageBasic.SaveAwaitImageProduct(files: files);
            return Ok(new OutputDefaultFile
            {
                Url = url.Replace("\\", "/")
            }); ;
        }

        [Route(UploadRouter.Post.PATCH)]
        [HttpPost]
        public async Task<IActionResult> UploadPostImage(IFormFile file)
        {
            var url = await _imageBasic.SavePostServer(files: file);
            string link = url.Replace("\\", "/");
            return Ok( new { data = new { link = link } });
        }

        [Route(UploadRouter.Root.PATCH)]
        [HttpPost]
        public async Task<IActionResult> UploadRootImage(IFormFile file)
        {
            var url = await _imageBasic.SaveRootServer(files: file);
            return Ok(new OutputDefaultFile
            {
                Url = url.Replace("\\", "/")
            }); ;
        }

    }
}
