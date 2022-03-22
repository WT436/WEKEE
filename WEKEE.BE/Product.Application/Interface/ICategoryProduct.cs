using Product.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface ICategoryProduct
    {
        Task<int?> CreateCategory(CategoryProductInsertDto cp);
    }
}
