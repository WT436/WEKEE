
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.PermissionAssignment;
using Account.Domain.ObjectValues.Input;

namespace Account.API.Src.AccountAreas
{
    public class PermissionAssignmentController : Controller
    {
        private readonly IPermissionAssignment _permissionAssignment;
        public PermissionAssignmentController(IPermissionAssignment permissionAssignment)
        {
            _permissionAssignment = permissionAssignment;
        }

        [Route(PermissionRouter.PermissionAssignmentAccount)]
        [HttpGet]
        public IActionResult BasicGet(int idRole, int pageIndex, int pageSize)
        {
            return Ok(_permissionAssignment.PermissionAssignmentDto(idRole: idRole,
                                                           pagedListInput: new PagedListInput() { PageIndex = pageIndex, PageSize = pageSize })
              );
        }

        [Route(PermissionRouter.PermissionAssignmentAccount)]
        [HttpPost]
        public IActionResult BasicUpdate([FromBody] PermissionAssignmentDto permissionAssignmentDto)
        {
            _permissionAssignment.UpdateOrInsert(permissionAssignmentDto);
            return Ok("true");
        }
    }
}
