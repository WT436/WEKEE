using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.Dto;
using System.Threading.Tasks;

namespace Product.API.Src.CategoryProductAPI
{
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategoryProduct _categoryProduct;
        public CategoryProductController(ICategoryProduct categoryProduct)
        {
            _categoryProduct = categoryProduct;
        }

        [HttpPost]
        [Route("/create-category")]
        public async Task<IActionResult> Index([FromBody] CategoryProductInsertDto categoryProductDto)
        {
           var data =  await _categoryProduct.CreateCategory(cp: categoryProductDto);

            return Ok(data);
        }
    }
}
