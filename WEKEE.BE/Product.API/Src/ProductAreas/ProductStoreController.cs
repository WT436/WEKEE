using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductStoreController : Controller
    {
        private readonly IProductContainer _productContainer;

        public ProductStoreController(IProductContainer productContainer)
        {
            _productContainer = productContainer;
        }

        [HttpPost]
        [Route("v1/api/create-product")]
        public async Task<IActionResult> Index([FromBody] ProductContainerInsertDto input)
        {
            var idAccount = Convert.ToInt32(HttpContext.Items["idAccount"]);
            var data = await _productContainer.ProcessProductContainer(input: input, idAccount: idAccount);
            return Ok();
        }
    }
}
