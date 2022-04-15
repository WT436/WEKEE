using Product.Application.Interface;
using Product.Domain.CoreDomain;
using Product.Domain.Shared.DataTransfer.FeatureProductDTO;
using Product.Domain.Shared.DataTransfer.ImageProductDTO;
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
        ProductQueries _productQueries = new ProductQueries();
        ProductImageQueries _productImageQueries = new ProductImageQueries();
        private readonly FeatureProductQueries _featureProductQueries = new FeatureProductQueries();
        public async Task<CartBasicProductDto> GetBasicProductFroCart(int id)
        {
            return await _productQueries.GetBasicProduct(id: id);
        }

        public async Task<List<ImageForProductDto>> GetImageProduct(int id)
        {
            var data = await _productImageQueries.GetBasicProduct(id);
            // sử lyas ảnh lỗi 
            return data;
        }

        public async Task<FeatureProductContainerDto> ProductCartRead(int id)
        {
            var data = await _featureProductQueries.GetBasicProduct(id);
            FeatureProductDomainCore featureProductDomainCore = new FeatureProductDomainCore();
            return featureProductDomainCore.ProcessFeatureKeyAttribute(data);
        }
    }
}
