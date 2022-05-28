using Account.Application.Service;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Enum;
using Account.Domain.ObjectValues.Input;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    [Route("v1/api/[controller]/[action]")]
    public class ResourceApiController : ControllerBase
    {
        private readonly IResourceAdmin _adminResource;
        public ResourceApiController(IResourceAdmin adminResource)
        {
            _adminResource = adminResource;
        }

        [HttpGet]
        public async Task<IActionResult> AdminResource(SearchOrderPageInput input)
        {
            var data = await _adminResource.GetResourcePageList(input: input);
            return Ok(data);
        }

        [HttpHead]
        public async Task<IActionResult> AdminResource(ExportFileInput input)
        {
            return Ok(20);
        }

        [HttpPost]
        public async Task<IActionResult> AdminResource([FromBody] ResourceReadDto input)
        {
            int idAccount = 1;
            var data = await _adminResource.InsertOrUpdateResource(input: input, idAccount: idAccount);
            return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> AdminResource([FromBody] ResourceLstChangeDto input)
        {
            var data = await _adminResource.EditUnitResource(input: input);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> AdminResource(string param1)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> AdminResource(List<int> ids)
        {
            var data = await _adminResource.DeleteResource(ids);
            return Ok(data);
        }

        [HttpOptions]
        public async Task AdminResource(int param1 , int param2)
        {
        }


        [HttpGet]
        public async Task<IActionResult> AdminResourceFtPermission(SearchOrderPageInput input)
        {
            var data = await _adminResource.GetResourceFtPermissionPageList(input: input);
            return Ok(data);
        }
    }
}
