using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductAttributeController : ControllerBase
    {
        [HttpGet]
        [Route("v1/api/product-attribute")]
        public async Task<IActionResult> Index()
        {
            return Ok("ProductAttribute");
        }
    }
}
