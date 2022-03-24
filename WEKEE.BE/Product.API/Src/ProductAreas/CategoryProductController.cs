using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
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
            var data = await _categoryProduct.CreateCategory(cp: categoryProductDto);

            return Ok(data);
        }

        [HttpGet]
        [Route("/get-all")]
        public async Task<IActionResult> SelectAll(SearchOrderPageInput input)
        {
            var data = await _categoryProduct.GetAllPageListCategory(input: input);
            return Ok(data);
        }

        [HttpPatch]
        [Route("/get-all")]
        public async Task<IActionResult> ChangeNumberOrder([FromBody] List<CategoryProductNumberOrderDto> input)
        {
            var numberChange = await _categoryProduct.ChangeNumberOrder(input);
            return Ok(numberChange);
        }

        [HttpPut]
        [Route("/get-all")]
        public async Task<IActionResult> ChangeCategory([FromBody] CategoryProductUpdateDto input)
        {
            var numberChange = await _categoryProduct.UpdateInfoCategory(input);
            return Ok(numberChange);
        }

        [HttpPut]
        [Route("/change-enlable")]
        public async Task<IActionResult> ChangeIsEnlable([FromBody] List<Entitys> input)
        {
            return Ok();
        }
    }
}
