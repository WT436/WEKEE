
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
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
        private readonly RoleQuery roleQuery = new RoleQuery();
        public int EditRole(RoleDto roleDto)
        {
            var action = MappingData.InitializeAutomapper().Map<Domain.Entitys.Role>(roleDto);
            roleQuery.Update(action);
            return 1;
        }

        public int EditRoleAsync(RoleDto roleDto)
        {
            throw new NotImplementedException();
        }

        public void InsertRole(RoleDto roleDto)
        {
            if(roleDto==null)
            {
                throw new ClientException(400, "You need to fill in all the information!");
            }
            if (String.IsNullOrEmpty(roleDto.Name) || String.IsNullOrEmpty(roleDto.Description))
            {
                throw new ClientException(400, "Invalid Name or Description !");
            }

            if (roleQuery.CountNameExact(roleDto.Name) != 0)
            {
                throw new ClientException(400, "Action name  already exists!");
            }
            if(roleQuery.CountId(roleDto.RoleId) == 0)
            {
                throw new ClientException(400, "Invalid RoleId!");
            }
            roleQuery.Insert(MappingData.InitializeAutomapper().Map<Domain.Entitys.Role>(roleDto));
        }

        public async Task InsertRoleAsync(RoleDto roleDto)
        {
            if (String.IsNullOrEmpty(roleDto.Name) || String.IsNullOrEmpty(roleDto.Description))
            {
                throw new ClientException(400, "Invalid Name or Description !");
            }

            if (await roleQuery.CountNameExactAsync(roleDto.Name) != 0)
            {
                throw new ClientException(400, "Action name  already exists!");
            }
            await roleQuery.InsertAsync(MappingData.InitializeAutomapper().Map<Domain.Entitys.Role>(roleDto));
        }

        public PagedListOutput<RoleDto> ListOrderByAscRole(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListOutput<RoleDto>> ListOrderByAscRoleAsync(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public PagedListOutput<RoleDto> ListOrderByDescRole(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListOutput<RoleDto>> ListOrderByDescRoleAsync(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public PagedListOutput<RoleDto> ListRoleBasic(PagedListInput pagedListInput)
        {
            var listData = roleQuery.GetAllListPage(pagedListInput);
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public async Task<PagedListOutput<RoleDto>> ListRoleBasicAsync(PagedListInput pagedListInput)
        {
            var listData = await roleQuery.GetAllListPageAsync(pagedListInput);
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public int RemoveRole(List<int> ids)
        {
            return roleQuery.Delete(ids);
        }

        public Task<int> RemoveRoleAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdateRole(List<int> ids)
        {
            return roleQuery.Update(roleQuery.GetAllLstById(ids).ToList());
        }

        public int UpdateRoleAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
