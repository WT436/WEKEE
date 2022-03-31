using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface ISpecificationAttribute
    {
        Task<int> Insert(SpecificationAttributeInsertDto input, int idAccount);
        
        /// <summary>
        /// Lấy thông tin Specification Attribute
        /// </summary>
        Task<PagedListOutput<SpecificationAttributeReadDto>> GetAllPageListCategory(SearchOrderPageInput input);
    }
}
