using Account.Domain.Shared.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Product.API.SettingUrl.AccountRouter;
using Account.Application.Resource;
using System.Threading.Tasks;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;

namespace Product.API.Src.AccountAreas
{
    public class ResourceController : Controller
    {
        private readonly IResource _resource;
        public ResourceController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.ResourceAccount)]
        [HttpGet]
        public async Task<IActionResult> GetData(SearchOrderPageInput searchOrderPageInput)
        {
            return Ok(await _resource.ListResourceBasicAsync(searchOrderPageInput));
        }

        [Route(PermissionRouter.ResourceAccount)]
        [HttpPost]
        public async Task<IActionResult> BasicCreate([FromBody] ResourceDto resourceDto)
        {
            return Ok(await _resource.InsertResourceAsync(resourceDto));
        }

        /// <summary>
        /// Cập nhật status
        /// </summary>
        [Route(PermissionRouter.ResourceAccount)]
        [HttpPut]
        public IActionResult BasicUpdate([FromBody] List<int> ids)
        {
            return Ok(_resource.UpdateResource(ids));
        }

        [Route(PermissionRouter.ResourceAccount)]
        [HttpPatch]
        public IActionResult BasicEdit([FromBody]ResourceDto resourceDto)
        {
            return Ok(_resource.EditResource(resourceDto));
        }

        [Route(PermissionRouter.ResourceAccount)]
        [HttpDelete]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_resource.RemoveResource(ids));
        }      
    }
}
