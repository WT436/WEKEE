using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProduct
    {
        Task<CartBasicProductDto> GetBasicProductFroCart(int id);
    }
}
