using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer.CategoryHomePageDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    /// <summary>
    /// Dùng để chỉnh sửa và hiển thị category bên ngoài trang home và các trang khác
    /// </summary>
    public interface ICategoryDisplay
    {
        /// <summary>
        /// Lấy dữ liệu theo điều kiện join của 2 bảng Category và categoryHomePage 
        /// </summary>
        Task<PagedListOutput<CategoryHomePageReadDto>> GetCategoryAndCateHome(SearchOrderPageInput input);
    }
}
