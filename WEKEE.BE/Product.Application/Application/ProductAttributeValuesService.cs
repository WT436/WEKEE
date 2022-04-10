using Product.Application.Interface;
using Product.Domain.Shared.DataTransfer.ProductAttributeValueDTO;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Application
{
    public class ProductAttributeValuesService : IProductAttributeValues
    {
        private readonly ProductAttributeValuesQueries _productAttributeValues = new ProductAttributeValuesQueries();
        public async Task<List<ProductAttributeValueReadDto>> ReadByAttributeKey(int idKey)
        {
            var data = _productAttributeValues.ReadByKey(idKey: idKey);
            return data;
        }
    }
}
