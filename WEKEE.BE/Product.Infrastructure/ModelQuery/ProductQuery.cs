using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Product.Infrastructure.ModelQuery
{
    public class ProductQuery
    {
        private readonly IUnitOfWork<ProductDBContext> unitOfWork =
                        new UnitOfWork<ProductDBContext>(new ProductDBContext());

        public int Insert(Domain.Shared.Entitys.Product input)
        {
            unitOfWork.GetRepository<Domain.Shared.Entitys.Product>().Insert(input);
            unitOfWork.SaveChanges();
            return input.Id;
        }
        public Domain.Shared.Entitys.Product InsertObject(Domain.Shared.Entitys.Product input)
        {
            unitOfWork.GetRepository<Domain.Shared.Entitys.Product>().Insert(input);
            unitOfWork.SaveChanges();
            return input;
        }

        public async Task<List<string>> GetAllProductAlbumByIdStore(int id)
        {
            var data = await unitOfWork.GetRepository<Domain.Shared.Entitys.Product>().GetAll(m => m.Supplier == id)
                                 .Select(m => m.ProductAlbum).Distinct().ToListAsync();
            return data;
        }
    }
}
