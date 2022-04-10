using Product.Domain.ObjectValues.Input;
using Product.Domain.ObjectValues.Output;
using Product.Domain.Shared.DataTransfer.ProductAttributeDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProductAttribute
    {
        public Task<int> InsertProductAttribute(ProductAttributeInsertDto input, int idAccount);

        /// <summary>
        /// Lấy thông tin Product Attribute
        /// </summary>
        Task<PagedListOutput<ProductAttributeReadDto>> GetAllPageListProductAttribute(SearchOrderPageInput input);

        /// <summary>
        /// Get product with type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<List<ProductAttributeReadTypesDto>> GetAllAttribute(int type);
        /// <summary>
        /// Read name and id from Category Product
        /// </summary>
        /// <returns></returns>
        Task<List<CateProReadIdAndNameDto>> CateProReadIdAndNameAccount();


    }
}
