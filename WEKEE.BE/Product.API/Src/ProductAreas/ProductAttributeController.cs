using Microsoft.AspNetCore.Mvc;
using Product.API.FilterAttributeCore.ActionFilters;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer.ProductAttributeDTO;
using System;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttribute _productAttribute;

        public ProductAttributeController(IProductAttribute productAttribute)
        {
            _productAttribute = productAttribute;
        }

        [HttpGet]
        [Route("v1/api/product-attribute")]
        public async Task<IActionResult> Index(SearchOrderPageInput input)
        {
            var data = await _productAttribute.GetAllPageListProductAttribute(input: input);
            return Ok(data);
        }

        [HttpPost]
        [Route("v1/api/product-attribute")]
        public async Task<IActionResult> CreateProductAtributeAdmin([FromBody] ProductAttributeInsertDto input)
        {
            var idAccount = HttpContext.Items["idAccount"];
            var data = await _productAttribute.InsertProductAttribute(input: input, idAccount: Convert.ToInt32(idAccount));
            return Ok(data);
        }

        [HttpGet]
        [Route("v1/api/product-attribute-type-one")]
        public async Task<IActionResult> ProductAtributeGetTypeOne(int input)
        {
            var data = await _productAttribute.GetAllAttribute(input);
            return Ok(data);
        } 
        
        [HttpGet]
        [Route("v1/api/get-name-account")]
        public async Task<IActionResult> GetNameAccount()
        {
            var data = await _productAttribute.CateProReadIdAndNameAccount();
            return Ok(data);
        }

    }
}
