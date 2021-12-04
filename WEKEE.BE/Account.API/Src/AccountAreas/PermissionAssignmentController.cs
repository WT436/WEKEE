using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;

namespace Account.API.Src.AccountAreas
{
    public class PermissionAssignmentController : Controller
    {
        private readonly IPermissionAssignment _permissionAssignment;
        public PermissionAssignmentController(IPermissionAssignment permissionAssignment)
        {
            _permissionAssignment = permissionAssignment;
        }

        [Route(PermissionRouter.PermissionAssignmentBasic.UPDATE)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] PermissionAssignmentDto permissionAssignmentDto)
        {
            _permissionAssignment.UpdateOrInsert(permissionAssignmentDto);
            return Ok("true");
        }

        [Route(PermissionRouter.PermissionAssignmentBasic.GET)]
        [HttpGet]
        public IActionResult BasicGet(int idRole, int pageIndex, int pageSize)
        {
            return Ok(_permissionAssignment.PermissionAssignmentDto(idRole: idRole,
                                                           pagedListInput: new PagedListInput() { PageIndex = pageIndex, PageSize = pageSize })
              );
        }

    }
}
