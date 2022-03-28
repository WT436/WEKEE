using Supplier.Domain.Shared.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Auth.Dtos;

namespace Supplier.Application.Interface
{
    public interface IProcessSupplier
    {
        /// <summary>
        /// Tạo mới nhà cung cấp
        /// </summary>
        Task<JwtResponse> CreateCreateShopBasic(SupplierCreateBasicDtos userAccount);
        /// <summary>
        /// Kiểm tra tồn tại của supplier
        /// </summary>
        Task<List<StoreSelectDtos>> CheckAnyStoreIsBoss(int idAccount);
    }
}
