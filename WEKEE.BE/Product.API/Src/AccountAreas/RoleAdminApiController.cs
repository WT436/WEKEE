using Account.Application.Interface;
using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.RoleDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class RoleAdminApiController : Controller
    {
        private readonly IRoleAdmin _adminRole;
        public RoleAdminApiController(IRoleAdmin adminRole)
        {
            _adminRole = adminRole;
        }

        [HttpGet]
        public async Task<IActionResult> AdminRole(SearchOrderPageInput input)
        {
            var data = await _adminRole.GetRolePageList(input: input);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> AdminSummaryRole(SearchTextInput input)
        {
            var data = await _adminRole.GetSummaryRole(input: input);
            return Ok(data);
        }

        [HttpHead]
        public async Task<IActionResult> AdminRole(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminRole([FromBody] RoleReadDto input)
        {
            int idAccount = 1;
            var data = await _adminRole.InsertOrUpdateRole(input: input, idAccount: idAccount);
            return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminRole([FromBody] RoleLstChangeDto input)
        {
            var data = await _adminRole.EditUnitRole(input: input);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> AdminRole(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminRole(List<int> ids)
        {
            var data = await _adminRole.DeleteRole(ids);
            return Ok(data);
        }

        [HttpOptions]
        public async Task AdminRole(int param1, int param2)
        {
        }
    }
}
