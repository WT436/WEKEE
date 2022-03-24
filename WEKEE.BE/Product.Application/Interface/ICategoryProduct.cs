using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface ICategoryProduct
    {
        Task<int?> CreateCategory(CategoryProductInsertDto cp);

        Task<PagedListOutput<CategoryProductReadDto>> GetAllPageListCategory(SearchOrderPageInput input);
        Task<int> ChangeNumberOrder(List<CategoryProductNumberOrderDto> input);
    }
}
