
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Action;
using Account.Domain.ObjectValues.Enum;

namespace Account.API.Src.AccountAreas
{
    public class ActionController : Controller
    {
        private readonly IAction _action;
        public ActionController(IAction action)
        {
            _action = action;
        }

        [HttpPost(PermissionRouter.ActionAccount)]
        public IActionResult BasicCreate([FromBody] ActionDto actionDto)
        {
            _action.InsertActionAsync(actionDto);
            return Ok("true");
        }

        [HttpGet(PermissionRouter.ActionAccount)]
        public async Task<IActionResult> BasicWatch(SearchOrderPageInput searchOrderPageInput)
        {
            var data = await _action.ListActionBasicAsync(searchOrderPageInput);
            return Ok(data);
        }

        [HttpPut(PermissionRouter.ActionAccount)]
        public async Task<IActionResult> BasicUpdate([FromBody] List<int> ids)
        {
            return Ok(_action.UpdateAction(ids));
        }

        [HttpPatch(PermissionRouter.ActionAccount)]
        public IActionResult BasicEdit([FromBody] ActionDto actionDto)
        {
            return Ok(_action.EditAction(actionDto));
        }

        [HttpDelete(PermissionRouter.ActionAccount)]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_action.RemoveAction(ids));
        }

    }
}
