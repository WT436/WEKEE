using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProductAttributeValues
    {
       Task<List<ProductAttributeValueReadDto>> ReadByAttributeKey(int idKey);
    }
}
