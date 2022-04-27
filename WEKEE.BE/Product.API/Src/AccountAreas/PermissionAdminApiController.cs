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
        //private readonly IAdminResource _adminResource;
        //public PermissionAdminApiController(IAdminResource adminResource)
        //{
        //    _adminResource = adminResource;
        //}

        [HttpGet]
        public async Task<IActionResult> AdminPermission(SearchOrderPageInput input)
        {
            //var data = await _adminResource.GetResourcePageList(input: input);
            //return Ok(data);
            return Ok();
        }

        [HttpHead]
        public async Task<IActionResult> AdminPermission(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminPermission([FromBody] PermissionReadDto input)
        {
            //int idAccount = 1;
            //var data = await _adminResource.InsertOrUpdateResource(input: input, idAccount: idAccount);
            //return Ok(data);
            return Ok(20);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminPermission([FromBody] PermissionLstChangeDto input)
        {
            //var data = await _adminResource.EditUnitResource(input: input);
            //return Ok(data);
            return Ok(20);
        }

        [HttpPut]
        public async Task<IActionResult> AdminPermission(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminPermission(List<int> ids)
        {
            //var data = await _adminResource.DeleteResource(ids);
            //return Ok(data);
            return Ok(20);
        }

        [HttpOptions]
        public async Task AdminPermission(int param1, int param2)
        {
        }
    }
}
