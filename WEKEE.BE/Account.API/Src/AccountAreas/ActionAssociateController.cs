using Account.Domain.Shared.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Account.API.SettingUrl.AccountRouter;
using Account.Application.ActionAssignment;
using Account.Domain.ObjectValues.Input;
using System.Threading.Tasks;

namespace Account.API.Src.AccountAreas
{
    public class ActionAssociateController : Controller
    {
        private readonly IActionAssignment _actionAssignment;
        public ActionAssociateController(IActionAssignment actionAssignment)
        {
            _actionAssignment = actionAssignment;
        }

        #region resource
        [Route(PermissionRouter.ActionAssignmentAccount)]
        [HttpGet]
        public IActionResult GetResourceByIdAction(int idAction, int pageIndex, int pageSize)
        {
            return Ok(_actionAssignment.ListActionAssignment(idPermission: idAction,
                                                             pagedListInput: new PagedListInput()
                                                             {
                                                                 PageIndex = pageIndex,
                                                                 PageSize = pageSize
                                                             })
            );
        }

        [Route(PermissionRouter.ActionAssignmentAccount)]
        [HttpPatch]
        public IActionResult BasicUpdate([FromBody] ActionAssignmentDto actionAssignmentDto)
        {
            _actionAssignment.UpdateOrInsert(actionAssignmentDto);
            return Ok("true");
        }
        #endregion

        #region Atomic
        [Route(PermissionRouter.GetActionByIdAtomicAccount)]
        [HttpGet]
        public async Task<IActionResult> GetActionByAtomicId(int idAtomic, int pageIndex, int pageSize)
        {
            var data = await _actionAssignment.GetActionByAtomic(idAtomic: idAtomic,
                                                                 pageIndex: pageIndex,
                                                                 pageSize: pageSize);
            return Ok(data);
        }
        #endregion

        #region Permission
        #endregion
    }
}
