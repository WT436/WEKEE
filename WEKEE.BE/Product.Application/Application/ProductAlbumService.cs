using Product.Application.Interface;
using Product.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Application
{
    public class ProductAlbumService : IProductAlbum
    {
        private readonly ProductQuery productQuery = new ProductQuery();
        public async Task<List<string>> GetallNameProductAlbum(int id)
        {
            var data = await productQuery.GetAllProductAlbumByIdStore(id: id);
            return data;
        }
    }
}
