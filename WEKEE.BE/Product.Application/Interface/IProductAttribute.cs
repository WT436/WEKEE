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
    }
}
