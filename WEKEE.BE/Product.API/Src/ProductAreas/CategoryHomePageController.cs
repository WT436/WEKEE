using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.ObjectValues.Input;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class CategoryHomePageController : Controller
    {
        private readonly ICategoryDisplay _categoryDisplay;
        public CategoryHomePageController(ICategoryDisplay categoryDisplay)
        {
            _categoryDisplay = categoryDisplay;
        }


        [HttpGet]
        [Route("/v1/api/get-data-category-review")]
        public async Task<IActionResult> GetCategoryReview(SearchOrderPageInput input)
        {
            var data = await _categoryDisplay.GetCategoryAndCateHome(input: input);
            return Ok(data);
        }

        [HttpGet]
        [Route("/v1/api/data-create-by-category-review")]
        public async Task<IActionResult> LoadDataCreateByCategoryHome(string IS_COMPONENT)
        {
            return Ok();
        }
    }
}
