using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using System;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductTagController : Controller
    {
        private readonly IProductTag _productTag;
        public ProductTagController(IProductTag productTag)
        {
            _productTag = productTag;
        }

        [HttpPost]
        [Route("v1/api/create-product-tag")]
        public async Task<IActionResult> Index([FromBody] string input)
        {
            var idAccount = Convert.ToInt32(HttpContext.Items["idAccount"]);
            var data = await _productTag.InsertProductTag(name: input, idAccount: idAccount);

            return Ok(data);
        }

        [HttpGet]
        [Route("v1/api/product-tag")]
        public async Task<IActionResult> GetPagelist(SearchOrderPageInput input)
        {
            var data = await _productTag.GetNamePageLst(input: input);
            return Ok(data);
        }
    }
}
