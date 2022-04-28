using Account.Application.Interface;
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.PermisionDTO;
using Account.Infrastructure.ADOQuery;
using Account.Infrastructure.EDMQuery;
using Account.Infrastructure.MappingExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Service
{
    public class PermissionAdminService : IPermissionAdmin
    {
        private readonly PermissionADO _permissionADO = new PermissionADO();
        private readonly PermissionEDM _permissionEDM = new PermissionEDM();
        public async Task<int> DeletePermission(List<int> ids)
        {
            if (ids != null)
            {
                return await _permissionEDM.Delete(ids);
            }
            return 0;
        }

        public async Task<int> EditUnitPermission(PermissionLstChangeDto input)
        {
            if ((PermissionProperty)input.Types == PermissionProperty.IS_ACTIVE)
            {
                var data = await _permissionADO.GetPermissionsById(input.Ids);
                data.ForEach(m => { m.IsActive = !m.IsActive; });
                return await _permissionEDM.UpdateIsActive(data);
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedListOutput<PermissionReadDto>> GetPermissionPageList(SearchOrderPageInput input)
        {
            var data = await _permissionADO.GetAllPageLstExactNotFTS(input);
            //var result = data.Select(m => MappingData.InitializeAutomapper().Map<PermissionReadDto>(m)).ToList();
            var count = (await _permissionADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            return new PagedListOutput<PermissionReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<List<PermissionSummaryReadDto>> GetSummaryPermission(SearchTextInput input)
        {
            return await _permissionADO.GetSummary(input: input);
        }

        public async Task<int> InsertOrUpdatePermission(PermissionReadDto input, int idAccount)
        {
            if (input != null)
            {
                var data = new PermissionAggregate().MapData(input: input, idAccount: idAccount);
                if (data.Id == 0)
                {
                    // insert
                    return await _permissionEDM.Insert(data);
                }
                else
                {
                    //update
                    return await _permissionEDM.UpdateFull(data);
                }
            }
            else
            {
                throw new ClientException(404, "");
            }
        }
    }
}
