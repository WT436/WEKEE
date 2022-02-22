using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.ResourceAction;
using Account.Domain.ObjectValues.Input;

namespace Account.API.Src.AccountAreas
{
    public class ResourceAssociateController : Controller
    {
        private readonly IResourceAction _resourceAction;
        public ResourceAssociateController(IResourceAction resourceAction)
        {
            _resourceAction = resourceAction;
        }

        [Route(PermissionRouter.ResourceActionAccount)]
        [HttpGet]
        public IActionResult GetResource(EntitySearchInput input)
        {
            return Ok(_resourceAction.GetResourceFromResourceAction(input));
        }

        [Route(PermissionRouter.ActionResourceAccount)]
        [HttpGet]
        public async Task<IActionResult> GetAction(EntitySearchInput input)
        {
            return Ok(await _resourceAction.GetActionFromResourceAction(input));
        }

        [Route(PermissionRouter.ResourceActionAccount)]
        [HttpPatch]
        public async Task<IActionResult> BasicUpdate([FromBody] ActionResourceUpdateDto actionResourceUpdateDto)
        {
            var updateSussce = await _resourceAction.UpdateOrInsertResourceAction(actionResourceUpdateDto);
            return Ok(updateSussce);
        }
    }
}
