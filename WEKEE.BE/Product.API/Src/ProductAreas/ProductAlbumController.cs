using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductAlbumController : Controller
    {
        private readonly IProductAlbum _productAlbum;

        public ProductAlbumController(IProductAlbum productAlbum)
        {
            _productAlbum = productAlbum;
        }

        [HttpGet]
        [Route("/v1/api/get-all-product-album")]
        public async Task<IActionResult> Index()
        {
            //read token => id store
            var data = await _productAlbum.GetallNameProductAlbum(1);
            return Ok(data);
        }
    }
}
