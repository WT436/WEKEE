using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class ResourceActionController : Controller
    {
        private readonly IResourceAction _resourceAction;
        public ResourceActionController(IResourceAction resourceAction)
        {
            _resourceAction = resourceAction;
        }

        [Route(PermissionRouter.ResourceActionBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch()
        {
            return Ok();
        }

        [Route(PermissionRouter.ResourceActionBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] ResourceActionDto resourceActionDto)
        {
            _resourceAction.UpdateOrInsertResourceAction(resourceActionDto);
            return Ok("true");
        }

        [Route(PermissionRouter.ResourceActionBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet(int idAction, int pageIndex ,int pageSize)
        {
            return Ok(_resourceAction.ResourceActionDtos(idAction: idAction,
                                                         pagedListInput: new PagedListInput() { PageIndex = pageIndex, PageSize = pageSize })
            );
        }
    }
}
