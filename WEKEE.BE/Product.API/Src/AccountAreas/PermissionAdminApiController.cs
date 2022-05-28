using Account.Application.Service;
using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.PermisionDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class PermissionAdminApiController : Controller
    {
        private readonly IPermissionAdmin _adminPermission;
        public PermissionAdminApiController(IPermissionAdmin adminPermission)
        {
            _adminPermission = adminPermission;
        }

        [HttpGet]
        public async Task<IActionResult> AdminPermission(SearchOrderPageInput input)
        {
            var data = await _adminPermission.GetPermissionPageList(input: input);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> AdminSummaryPermission(SearchTextInput input)
        {
            var data = await _adminPermission.GetSummaryPermission(input: input);
            return Ok(data);
        }

        [HttpHead]
        public async Task<IActionResult> AdminPermission(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminPermission([FromBody] PermissionReadDto input)
        {
            int idAccount = 1;
            var data = await _adminPermission.InsertOrUpdatePermission(input: input, idAccount: idAccount);
            return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminPermission([FromBody] PermissionLstChangeDto input)
        {
            var data = await _adminPermission.EditUnitPermission(input: input);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> AdminPermission(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminPermission(List<int> ids)
        {
            var data = await _adminPermission.DeletePermission(ids);
            return Ok(data);
        }

        [HttpOptions]
        public async Task AdminPermission(int param1, int param2)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AdminAddResourceFtPermission([FromBody]PermissionFtResourceInsertDto input)
        {
            int idAccount = 1;
            var data = await _adminPermission.InsertOrUpdatePermissionFtResource(input: input, idAccount: idAccount);
            return Ok(data);
        }

    }
}
