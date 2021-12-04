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
    public class ActionController : Controller
    {
        private readonly IAction _action;
        public ActionController(IAction action)
        {
            _action = action;
        }

        [Route(PermissionRouter.ActionBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch(OrderByPageListInput orderByPageListInput)
        {
            var data = _action.ListOrderByAscAction(orderByPageListInput);
            return Ok(data);
        }

        [Route(PermissionRouter.ActionBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] List<int> ids)
        {
            return Ok(_action.UpdateAction(ids));
        }

        [Route(PermissionRouter.ActionBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList([FromBody] OrderByPageListInput orderByPagedListInput)
        {
            PagedListOutput<ActionDto> data;

            if (orderByPagedListInput.OrderBy.ToUpper() == "ASCENT")
            {
                data = _action.ListOrderByAscAction(orderByPagedListInput);
            }
            else if (orderByPagedListInput.OrderBy.ToUpper() == "DECREASE")
            {
                data = _action.ListOrderByDescAction(orderByPagedListInput);
            }
            else
            {
                data = _action.ListActionBasic(orderByPagedListInput);
            };
            return Ok(data);
        }

        [Route(PermissionRouter.ActionBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit([FromBody] ActionDto actionDto)
        {
            return Ok(_action.EditAction(actionDto));
        }

        [Route(PermissionRouter.ActionBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_action.RemoveAction(ids));
        }

        [Route(PermissionRouter.ActionBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate([FromBody] ActionDto actionDto)
        {
            _action.InsertAction(actionDto);
            return Ok("true");
        }
    }
}
