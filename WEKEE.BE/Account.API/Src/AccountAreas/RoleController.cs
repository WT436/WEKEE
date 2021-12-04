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
    public class RoleController : Controller
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }

        [Route(PermissionRouter.RoleBasic.WATCH)]
        [HttpGet]
        public IActionResult BasicWatch(OrderByPageListInput orderByPageListInput)
        {
            var data = _role.ListOrderByAscRole(orderByPageListInput);
            return Ok(data);
        }

        [Route(PermissionRouter.RoleBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] List<int> ids)
        {
            return Ok(_role.UpdateRole(ids));
        }

        [Route(PermissionRouter.RoleBasic.LIST)]
        [HttpPost]
        public IActionResult BasicList([FromBody] OrderByPageListInput orderByPagedListInput)
        {
            PagedListOutput<RoleDto> data;

            if (orderByPagedListInput.OrderBy.ToUpper() == "ASCENT")
            {
                data = _role.ListOrderByAscRole(orderByPagedListInput);
            }
            else if (orderByPagedListInput.OrderBy.ToUpper() == "DECREASE")
            {
                data = _role.ListOrderByDescRole(orderByPagedListInput);
            }
            else
            {
                data = _role.ListRoleBasic(orderByPagedListInput);
            };
            return Ok(data);
        }

        [Route(PermissionRouter.RoleBasic.EDIT)]
        [HttpPost]
        public IActionResult BasicEdit([FromBody] RoleDto roleDto)
        {
            return Ok(_role.EditRole(roleDto));
        }

        [Route(PermissionRouter.RoleBasic.DELETE)]
        [HttpDelete]
        public IActionResult BasicDelete(List<int> ids)
        {
            return Ok(_role.RemoveRole(ids));
        }

        [Route(PermissionRouter.RoleBasic.CREATE)]
        [HttpPost]
        public IActionResult BasicCreate([FromBody] RoleDto roleDto)
        {
            _role.InsertRole(roleDto);
            return Ok("true");
        }
    }
}
