using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.GroupPermissionDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class GroupPermissionAdminApiController : Controller
    {
        //private readonly IAdminResource _adminResource;
        //public GroupPermissionAdminApiController(IAdminResource adminResource)
        //{
        //    _adminResource = adminResource;
        //}

        [HttpGet]
        public async Task<IActionResult> AdminGroupPermission(SearchOrderPageInput input)
        {
            //var data = await _adminResource.GetResourcePageList(input: input);
            //return Ok(data);
            return Ok();
        }

        [HttpHead]
        public async Task<IActionResult> AdminGroupPermission(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminGroupPermission([FromBody] GroupPermissionReadDto input)
        {
            //int idAccount = 1;
            //var data = await _adminResource.InsertOrUpdateResource(input: input, idAccount: idAccount);
            //return Ok(data);
            return Ok(20);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminGroupPermission([FromBody] GroupPermissionLstChangeDto input)
        {
            //var data = await _adminResource.EditUnitResource(input: input);
            //return Ok(data);
            return Ok(20);
        }

        [HttpPut]
        public async Task<IActionResult> AdminGroupPermission(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminGroupPermission(List<int> ids)
        {
            //var data = await _adminResource.DeleteResource(ids);
            //return Ok(data);
            return Ok(20);
        }

        [HttpOptions]
        public async Task AdminGroupPermission(int param1, int param2)
        {
        }
    }
}
