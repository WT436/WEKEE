using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer;
using Product.Domain.Shared.DataTransfer.CategoryProductDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface ICategoryProduct
    {
        /// <summary>
        /// Tạo mới một category
        /// </summary>
        Task<int?> CreateCategory(CategoryProductInsertDto cp);
        /// <summary>
        /// Lấy thông tin category
        /// </summary>
        Task<PagedListOutput<CategoryProductReadDto>> GetAllPageListCategory(SearchOrderPageInput input);
        /// <summary>
        /// Thay đổi vị trí hiển thị
        /// </summary>
        Task<int> ChangeNumberOrder(List<CategoryProductNumberOrderDto> input);
        /// <summary>
        /// Thay đổi thông tin hiển thị
        /// </summary>
        Task<int> UpdateInfoCategory(CategoryProductUpdateDto input);
        /// <summary>
        /// Ẩn hiện category
        /// </summary>
        Task<int> ChangeEnableCategory(List<Entitys> id);
        /// <summary>
        /// Di chuyển category qua category khác
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> MoveCategoryMain(int id);

        Task<CategoryProductReadChildrenDto> SearchAllCategory(SearchOrderPageInput input);

        Task<List<CategoryProductReadMapDto>> GetMapCategory();

        Task<List<CateProReadIdAndNameDto>> ReadNameAndId();

        Task<List<CategoryBreadcrumbDtos>> GetCategoryBreadcrumbDtos(int idProduct);
    }
}
