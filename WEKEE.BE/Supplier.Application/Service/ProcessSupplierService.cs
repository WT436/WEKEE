using Supplier.Domain.BoundedContext;
using Supplier.Domain.Shared.DataTransfer;
using Supplier.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Auth.Dtos;

namespace Supplier.Application.Service
{
    #region interface IProcessSupplier
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

        /// <summary>
        /// Kiểm tra token của store và trả về phân quyền
        /// </summary>
        //Task CheckTokenStore(string token);
    }
    #endregion

    #region class ProcessSupplierService
    public class ProcessSupplierService : IProcessSupplier
    {
        private readonly TokenToJWT _tokenToJWT = new TokenToJWT();
        private readonly SupplierMappingQueries _supplierMappingQueries = new SupplierMappingQueries();
        private readonly SupplierQueries _supplierQueries = new SupplierQueries();

        public async Task<List<StoreSelectDtos>> CheckAnyStoreIsBoss(int idAccount)
        {
            var data = await _supplierMappingQueries.MappingStoreByIdStaff(idAccount);
            // check quyền
            // nap quyen
            var dataRet = new List<StoreSelectDtos>();
            if (data.Count > 0)
            {
                foreach (var item in data.ToList())
                {
                    dataRet.Add(new StoreSelectDtos
                    {
                        Id = item.SupplierId,
                        NameStore = await _supplierQueries.GetNameStore(item.SupplierId),
                        NameRole = "Boss_Store_2",
                        IsBoss = item.IsBoss
                    });
                };
            }
            return dataRet;
        }

        public Task<JwtResponse> CreateCreateShopBasic(SupplierCreateBasicDtos userAccount)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
