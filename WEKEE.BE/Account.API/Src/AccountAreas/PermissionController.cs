
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.Permission;
using Account.Domain.ObjectValues.Enum;

namespace Account.API.Src.AccountAreas
{
    public class PermissionController : Controller
    {
        private readonly IPermission  _permission;
        public PermissionController(IPermission permission)
        {
            _permission = permission;
        }

        [HttpGet(PermissionRouter.PermissionAccount)]
        public IActionResult Get(OrderByPageListInput orderByPageListInput)
        {
            var data = _permission.ListOrderByAscPermission(orderByPageListInput);
            return Ok(data);
        }

        [HttpPost(PermissionRouter.PermissionAccount)]
        public IActionResult Create([FromBody] PermissionDto permission)
        {
            _permission.InsertPermission(permission);
            return Ok("true");
        }

        [HttpPut(PermissionRouter.PermissionAccount)]
        public IActionResult Update([FromBody] List<int> ids)
        {
            return Ok(_permission.UpdatePermission(ids));
        }

        [HttpPatch(PermissionRouter.PermissionAccount)]
        public IActionResult BasicEdit([FromBody] PermissionDto  permission)
        {
            return Ok(_permission.EditPermission(permission));
        }

        [HttpDelete(PermissionRouter.PermissionAccount)]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_permission.RemovePermission(ids));
        }
    }
}
