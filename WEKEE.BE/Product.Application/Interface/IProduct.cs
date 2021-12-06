using Product.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProduct
    {
        List<string> AlbumProduct(int idSupplier);
        Task<string> CreateProduct(CreateProductDtos createProductDtos, int supplier);
        Task<UnitCardDtos> GetUnitProduct(int id);
        Task<bool> CheckIdProduct(int id);
    }
}
