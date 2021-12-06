using Supplier.Domain.Dto;
using Supplier.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Interface
{
    public interface ISupplier
    {
        Task<SupplierDtos> GetdataSupplier(int idAccount, string numberPhone, string email,
                                           string password, string haskPass, string passwordHashAlgorithm, string name);
        Task<SupplierDtos> CheckPassShop(int idAccount, string passShop);
    }
}
