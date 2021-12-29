
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.ResourceAction;
using Account.Domain.ObjectValues.Enum;

namespace Account.API.Src.AccountAreas
{
    public class ResourceActionController : Controller
    {
        private readonly IResourceAction _resourceAction;
        public ResourceActionController(IResourceAction resourceAction)
        {
            _resourceAction = resourceAction;
        }

        [Route(PermissionRouter.ResourceActionAccount)]
        [HttpGet]
        public IActionResult GetResource(int id, int pageIndex, int pageSize)
        {
            return Ok(_resourceAction.ResourceActionDtos(idAction: id,
                                                         pagedListInput: new PagedListInput() { PageIndex = pageIndex,
                                                                                                PageSize = pageSize })
            );
        }

        [Route(PermissionRouter.ActionResourceAccount)]
        [HttpGet]
        public IActionResult GetAction(int id, int pageIndex, int pageSize)
        {
            return Ok(_resourceAction.ResourceActionDtos(idAction: id,
                                                         pagedListInput: new PagedListInput()
                                                         {
                                                             PageIndex = pageIndex,
                                                             PageSize = pageSize
                                                         })
            );
        }

        [Route(PermissionRouter.ResourceActionAccount)]
        [HttpPatch]
        public IActionResult BasicUpdate([FromBody] ActionResourceDto resourceActionDto)
        {
            _resourceAction.UpdateOrInsertResourceAction(resourceActionDto);
            return Ok("true");
        }

    }
}
