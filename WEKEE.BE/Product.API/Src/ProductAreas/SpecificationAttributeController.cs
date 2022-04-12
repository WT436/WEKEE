using Account.Domain.BoundedContext;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer;
using Product.Domain.Shared.DataTransfer.SpecificationAttributeDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class SpecificationAttributeController : ControllerBase
    {
        private readonly ISpecificationAttribute _specificationAttribute;

        public SpecificationAttributeController(ISpecificationAttribute specificationAttribute)
        {
            _specificationAttribute = specificationAttribute;
        }

        [HttpGet]
        [Route("v1/api/specification-attribute")]
        public async Task<IActionResult> Index(SearchOrderPageInput input)
        {
            var data = await _specificationAttribute.GetAllPageListCategory(input: input);
            return Ok(data);
        }

        [HttpPost]
        [Route("v1/api/create-specification-attribute")]
        public async Task<IActionResult> CreateSpecificationAttribute([FromBody] SpecificationAttributeInsertDto input)
        {
            TokenToJWT tokenToJWT = new TokenToJWT();
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            var idAccount = tokenToJWT.DecryptionToken(token).Id;

            var data = await _specificationAttribute.Insert(input: input,
                                                        idAccount: idAccount);
            return Ok(data);
        }

        [HttpGet]
        [Route("v1/api/load-name-group-spec")]
        public async Task<IActionResult> LoadSpecNameGroupProduct(List<int> input)
        {
            var data = await _specificationAttribute.GetAllNameGroupSpec(input);
            return Ok(data);
        }

        [HttpGet]
        [Route("v1/api/load-specification-data")]
        public async Task<IActionResult> LoadSpecCreateProduct(string nameGroup, List<int> category)
        {
            var data = await _specificationAttribute.GetAllKeyByGroupSpec(category, nameGroup);
            return Ok(data);
        }
    }
}
