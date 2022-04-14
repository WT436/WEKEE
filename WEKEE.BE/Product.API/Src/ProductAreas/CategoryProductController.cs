using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using Product.Domain.Shared.DataTransfer.CategoryProductDTO;
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
        [Route("/v1/api/create-category")]
        public async Task<IActionResult> Index([FromBody] CategoryProductInsertDto categoryProductDto)
        {
            var data = await _categoryProduct.CreateCategory(cp: categoryProductDto);
            return Ok(data);
        }

        [HttpGet]
        [Route("/v1/api/category-product-get-all")]
        public async Task<IActionResult> SelectAll(SearchOrderPageInput input)
        {
            var data = await _categoryProduct.GetAllPageListCategory(input: input);
            return Ok(data);
        }

        [HttpPatch]
        [Route("/v1/api/get-all")]
        public async Task<IActionResult> ChangeNumberOrder([FromBody] List<CategoryProductNumberOrderDto> input)
        {
            var numberChange = await _categoryProduct.ChangeNumberOrder(input);
            return Ok(numberChange);
        }

        [HttpPut]
        [Route("/v1/api/get-all")]
        public async Task<IActionResult> ChangeCategory([FromBody] CategoryProductUpdateDto input)
        {
            var numberChange = await _categoryProduct.UpdateInfoCategory(input);
            return Ok(numberChange);
        }

        [HttpPut]
        [Route("/v1/api/change-enlable")]
        public async Task<IActionResult> ChangeIsEnlable([FromBody] List<Entitys> input)
        {
            var numberChange = await _categoryProduct.ChangeEnableCategory(input);
            return Ok(numberChange);
        }

        [HttpGet]
        [Route("/v1/api/get-map-category")]
        public async Task<IActionResult> GetMapCategory()
        {
            var data = await _categoryProduct.GetMapCategory();
            return Ok(data);
        }

        [HttpGet]
        [Route("/v1/api/get-map-category-name-id")]
        public async Task<IActionResult> GetNameAndId()
        {
            var data = await _categoryProduct.ReadNameAndId();
            return Ok(data);
        }

        [HttpGet]
        [Route("/v1/api/get-data-category-becrum")]
        public async Task<IActionResult> GetCategoryBreadcrumb(int input)
        {
            var data = await _categoryProduct.GetCategoryBreadcrumbDtos(input);
            return Ok(data);
        }

    }
}
