
using Account.Domain.BoundedContext;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Permission
{
    public class PermissionService : IPermission
    {
        private readonly PermissionQuery _permissionQuery = new PermissionQuery();
        private readonly UserAccountQuery _accountQuery = new UserAccountQuery();

        public int EditPermission(PermissionDto permission)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertPermissionAsync(PermissionDto permission)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedListOutput<PermissionDto>> ListPermissionBasicAsync(SearchOrderPageInput searchOrderPageInput)
        {
            var listData = await _permissionQuery.GetAllListPageAsync(searchOrderPageInput);
            return new PagedListOutput<PermissionDto>
            {
                Items = listData.Items.Select(emp =>
                {
                    var dataReturn = MappingData.InitializeAutomapper().Map<PermissionDto>(emp);
                    dataReturn.CreateByName = _accountQuery.GetNameAccount(emp.CreateBy);
                    return dataReturn;
                }).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public int RemovePermission(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdatePermission(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
