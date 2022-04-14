using Product.Application.Interface;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using Product.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Application
{
    public class ProductService : IProduct
    {
        ProductQueries _product = new ProductQueries();
        public async Task<CartBasicProductDto> GetBasicProductFroCart(int id)
        {
           return await _product.GetBasicProduct(id: id);
        }
    }
}
