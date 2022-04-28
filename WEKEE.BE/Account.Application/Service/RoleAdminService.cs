using Account.Application.Interface;
using Account.Domain.Aggregate;
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.RoleDTO;
using Account.Infrastructure.ADOQuery;
using Account.Infrastructure.EDMQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Service
{
    public class RoleAdminService : IRoleAdmin
    {
        private readonly RoleADO _roleADO = new RoleADO();
        private readonly RoleEDM _roleEDM = new RoleEDM();
        public async Task<int> DeleteRole(List<int> ids)
        {
            if (ids != null)
            {
                return await _roleEDM.Delete(ids);
            }
            return 0;
        }

        public async Task<int> EditUnitRole(RoleLstChangeDto input)
        {
            if ((RoleProperty)input.Types == RoleProperty.IS_ACTIVE)
            {
                var data = await _roleADO.GetRolesById(input.Ids);
                data.ForEach(m => { m.IsActive = !m.IsActive; });
                return await _roleEDM.UpdateIsActive(data);
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedListOutput<RoleReadDto>> GetRolePageList(SearchOrderPageInput input)
        {
            var data = await _roleADO.GetAllPageLstExactNotFTS(input);
            //var result = data.Select(m => MappingData.InitializeAutomapper().Map<RoleReadDto>(m)).ToList();
            var count = (await _roleADO.GetCountForGetAllPageLst(input)).FirstOrDefault().TotalCount;
            return new PagedListOutput<RoleReadDto>
            {
                Items = data,
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                TotalPages = (count / input.PageSize),
                TotalCount = count
            };
        }

        public async Task<int> InsertOrUpdateRole(RoleReadDto input, int idAccount)
        {
            if (input != null)
            {
                var data = new RoleAggregate().MapData(input: input, idAccount: idAccount);
                if (data.Id == 0)
                {
                    // insert
                    return await _roleEDM.Insert(data);
                }
                else
                {
                    //update
                    return await _roleEDM.UpdateFull(data);
                }
            }
            else
            {
                throw new ClientException(404, "");
            }
        }
    }
}
