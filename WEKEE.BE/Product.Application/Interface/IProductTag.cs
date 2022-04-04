using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer.ProductTagDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProductTag
    {
        Task<int> InsertProductTag(string name, int idAccount);

        Task<PagedListOutput<ProductTagReadDto>> GetNamePageLst(SearchOrderPageInput input);
    }
}
