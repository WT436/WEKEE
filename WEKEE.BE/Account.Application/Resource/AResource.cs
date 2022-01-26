using Account.Domain.BoundedContext;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues.Enum;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Collections;
using Utils.Exceptions;

namespace Account.Application.Resource
{
    public class AResource : IResource
    {
        private readonly ResourceQuery resourceQuery = new ResourceQuery();
        private readonly UserAccountQuery accountQuery = new UserAccountQuery();

        public async Task<PagedListOutput<ResourceDto>> ListResourceBasicAsync(SearchOrderPageInput searchOrderPageInput)
        {
            var listData = await resourceQuery.GetAllListPageAsync(searchOrderPageInput);
            return new PagedListOutput<ResourceDto>
            {
                Items = listData.Items.Select(emp =>
                {
                    var dataReturn = MappingData.InitializeAutomapper().Map<ResourceDto>(emp);
                    dataReturn.CreateBy = accountQuery.GetNameAccount(emp.CreateBy);
                    return dataReturn;
                }).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public async Task<int> InsertResourceAsync(ResourceDto resource)
        {
            if (resource.TypesRsc == null || !Enum.IsDefined(typeof(TYPES_RESOURCE), resource.TypesRsc.ToUpper()))
            {
                throw new ClientException(400, "Invalid Types!");
            }
            if (resourceQuery.CountNameAndTypesExact(resource.Name, resource.TypesRsc) != 0)
            {
                throw new ClientException(400, "Url already exists!");
            }
            var data = MappingData.InitializeAutomapper().Map<Domain.Shared.Entitys.Resource>(resource);
            return await resourceQuery.InsertAsync(data);
        }

        public int RemoveResource(List<int> ids)
        {
            return resourceQuery.Delete(ids);
        }

        public int UpdateResource(List<int> ids)
        {
            var dsada = resourceQuery.GetAllLstById(ids).Select(m => { m.IsActive = !m.IsActive; return m; }).ToList();
            return resourceQuery.Update(dsada);
        }

        public int EditResource(ResourceDto resourceDto)
        {
            if (string.IsNullOrEmpty(resourceDto.Name) || string.IsNullOrEmpty(resourceDto.TypesRsc))
            {
                throw new ClientException(400, "Invalid Types!");
            }
            var resource = MappingData.InitializeAutomapper().Map<Domain.Shared.Entitys.Resource>(resourceDto);
            resource.UpdatedAt = DateTime.Now;
            return resourceQuery.Update(resource);
        }
    }
}
