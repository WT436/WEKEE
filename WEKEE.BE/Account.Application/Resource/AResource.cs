using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.ObjectValues.Enum;
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
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public int InsertResource(ResourceDto resource)
        {
            if (resource.TypesRsc == null || resource.TypesRsc.ToUpper() != "URL")
            {
                throw new ClientException(400, "Invalid Types!");
            }
            if (resourceQuery.CountNameAndTypesExact(resource.Name, resource.TypesRsc) != 0)
            {
                throw new ClientException(400, "Url already exists!");
            }
            return resourceQuery.Insert(MappingData.InitializeAutomapper().Map<Domain.Entitys.Resource>(resource));
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
            var data = MappingData.InitializeAutomapper().Map<Domain.Entitys.Resource>(resource);
            return await resourceQuery.InsertAsync(data);
        }

        public int RemoveResource(List<int> ids)
        {
            return resourceQuery.Delete(ids);
        }

        public Task<int> RemoveResourceAsync(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateResource(List<int> ids)
        {
            var dsada = resourceQuery.GetAllLstById(ids).Select(m => { m.IsActive = !m.IsActive; return m; }).ToList();
            return resourceQuery.Update(dsada);
        }

        public int UpdateResourceAsync(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public int EditResource(ResourceDto resourceDto)
        {
            if(string.IsNullOrEmpty(resourceDto.Name) || string.IsNullOrEmpty(resourceDto.TypesRsc))
            {
                throw new ClientException(400, "Invalid Types!");
            }
            var resource = MappingData.InitializeAutomapper().Map<Domain.Entitys.Resource>(resourceDto);
            resource.UpdatedAt = DateTime.Now;
            return resourceQuery.Update(resource);
        }

        public int EditResourceAsync(ResourceDto resource)
        {
            throw new System.NotImplementedException();
        }
    }
}
