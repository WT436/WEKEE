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
    public class PermissionController : Controller
    {
        private readonly IPermission  _permission;
        public PermissionController(IPermission permission)
        {
            _permission = permission;
        }

        [Route(PermissionRouter.PermissionBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch(OrderByPageListInput orderByPageListInput)
        {
            var data = _permission.ListOrderByAscPermission(orderByPageListInput);
            return Ok(data);
        }

        [Route(PermissionRouter.PermissionBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] List<int> ids)
        {
            return Ok(_permission.UpdatePermission(ids));
        }

        [Route(PermissionRouter.PermissionBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList([FromBody] OrderByPageListInput orderByPagedListInput)
        {
            PagedListOutput<PermissionDto> data;

            if (orderByPagedListInput.OrderBy.ToUpper() == "ASCENT")
            {
                data = _permission.ListOrderByAscPermission(orderByPagedListInput);
            }
            else if (orderByPagedListInput.OrderBy.ToUpper() == "DECREASE")
            {
                data = _permission.ListOrderByDescPermission(orderByPagedListInput);
            }
            else
            {
                data = _permission.ListPermissionBasic(orderByPagedListInput);
            };
            return Ok(data);
        }

        [Route(PermissionRouter.PermissionBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit([FromBody] PermissionDto  permission)
        {
            return Ok(_permission.EditPermission(permission));
        }

        [Route(PermissionRouter.PermissionBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_permission.RemovePermission(ids));
        }

        [Route(PermissionRouter.PermissionBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate([FromBody] PermissionDto permission)
        {
            _permission.InsertPermission(permission);
            return Ok("true");
        }
    }
}
