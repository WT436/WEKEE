
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

namespace Account.Application.Permission
{
    public class APermission : IPermission
    {
        private readonly PermissionQuery permissionQuery = new PermissionQuery();
        public int EditPermission(PermissionDto permissionDto)
        {
            var action = MappingData.InitializeAutomapper().Map<Domain.Entitys.Permission>(permissionDto);
            permissionQuery.Update(action);
            return 1;
        }

        public int EditPermissionAsync(PermissionDto permission)
        {
            throw new NotImplementedException();
        }

        public void InsertPermission(PermissionDto permission)
        {
            if (String.IsNullOrEmpty(permission.Name) || String.IsNullOrEmpty(permission.Description))
            {
                throw new ClientException(400, "Invalid Name or Description !");
            }

            if (permissionQuery.CountNameExact(permission.Name) != 0)
            {
                throw new ClientException(400, "Action name  already exists!");
            }
            permissionQuery.Insert(MappingData.InitializeAutomapper().Map<Domain.Entitys.Permission>(permission));
        }

        public async Task InsertPermissionAsync(PermissionDto permission)
        {
            if (String.IsNullOrEmpty(permission.Name) || String.IsNullOrEmpty(permission.Description))
            {
                throw new ClientException(400, "Invalid Name or Description !");
            }

            if (await permissionQuery.CountNameExactAsync(permission.Name) != 0)
            {
                throw new ClientException(400, "Action name  already exists!");
            }
            await permissionQuery.InsertAsync(MappingData.InitializeAutomapper().Map<Domain.Entitys.Permission>(permission));

        }

        public PagedListOutput<PermissionDto> ListOrderByAscPermission(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListOutput<PermissionDto>> ListOrderByAscPermissionAsync(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public PagedListOutput<PermissionDto> ListOrderByDescPermission(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListOutput<PermissionDto>> ListOrderByDescPermissionAsync(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public PagedListOutput<PermissionDto> ListPermissionBasic(PagedListInput pagedListInput)
        {
            var listData = permissionQuery.GetAllListPage(pagedListInput);
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public async Task<PagedListOutput<PermissionDto>> ListPermissionBasicAsync(PagedListInput pagedListInput)
        {
            var listData = await permissionQuery.GetAllListPageAsync(pagedListInput);
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public int RemovePermission(List<int> ids)
        {
            return permissionQuery.Delete(ids);
        }

        public Task<int> RemovePermissionAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdatePermission(List<int> ids)
        {
            return permissionQuery.Update(permissionQuery.GetAllLstById(ids).ToList());
        }

        public int UpdatePermissionAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
