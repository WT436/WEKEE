using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class ResourceController : Controller
    {
        private readonly IResource _resource;
        public ResourceController(IResource resource)
        {
            _resource = resource;
        }

        [Route(PermissionRouter.ResourceBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch(OrderByPageListInput orderByPageListInput)
        {
            var data = _resource.ListOrderByAscResource(orderByPageListInput);
            return Ok(data);
        }

        [Route(PermissionRouter.ResourceBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] List<int> ids)
        {
            return Ok(_resource.UpdateResource(ids));
        }

        [Route(PermissionRouter.ResourceBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList([FromBody] OrderByPageListInput orderByPagedListInput)
        {
            PagedListOutput<ResourceDto> data;

            if (orderByPagedListInput.OrderBy.ToUpper() == "ASCENT")
            {
                data = _resource.ListOrderByAscResource(orderByPagedListInput);
            }
            else if (orderByPagedListInput.OrderBy.ToUpper() == "DECREASE")
            {
                data = _resource.ListOrderByDescResource(orderByPagedListInput);
            }
            else
            {
                data = _resource.ListResourceBasic(orderByPagedListInput);
            };
            return Ok(data);
        }

        [Route(PermissionRouter.ResourceBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit([FromBody] ResourceDto resourceDto)
        {
            return Ok(_resource.EditResource(resourceDto));
        }

        [Route(PermissionRouter.ResourceBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_resource.RemoveResource(ids));
        }

        [Route(PermissionRouter.ResourceBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate([FromBody] ResourceDto resourceDto)
        {
            _resource.InsertResource(resourceDto);
            return Ok("true");
        }
    }
}
