
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

namespace Account.Application.Role
{
    public class ARole : IRole
    {
        private readonly RoleQuery _roleQuery = new RoleQuery();
        private readonly UserAccountQuery _accountQuery = new UserAccountQuery();

        public int EditRole(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertRoleAsync(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedListOutput<RoleDto>> ListRoleBasicAsync(SearchOrderPageInput searchOrderPageInput)
        {
            var listData = await _roleQuery.GetAllListPageAsync(searchOrderPageInput);
            return new PagedListOutput<RoleDto>
            {
                Items = listData.Items.Select(emp =>
                {
                    var dataReturn = MappingData.InitializeAutomapper().Map<RoleDto>(emp);
                    dataReturn.CreateByName = _accountQuery.GetNameAccount(emp.CreateBy);
                    var dataRoleMain = emp.RoleId == 0 ? null : _roleQuery.GetById(emp.RoleId);
                    dataReturn.RoleMainName = dataRoleMain == null ? "" : dataRoleMain.Name;
                    return dataReturn;
                }).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public int RemoveRole(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdateRole(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
