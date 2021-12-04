using Account.Application.Interface;
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Collections;
using Utils.Exceptions;

namespace Account.Application.Application
{
    public class Resource : IResource
    {
        private readonly ResourceQuery resourceQuery = new ResourceQuery();

        public PagedListOutput<ResourceDto> ListResourceBasic(PagedListInput pagedListInput)
        {
            var listData = resourceQuery.GetAllListPage(pagedListInput);
            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public async Task<PagedListOutput<ResourceDto>> ListResourceBasicAsync(PagedListInput pagedListInput)
        {
            var listData = await resourceQuery.GetAllListPageAsync(pagedListInput);

            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public PagedListOutput<ResourceDto> ListOrderByAscResource(OrderByPageListInput orderByPageListInput)
        {
            IPagedList<Domain.Entitys.Resource> listData;

            if (orderByPageListInput.Property.ToUpper().Equals("NAME"))
            {
                listData = resourceQuery.GetNameOrderByAsc(orderByPageListInput);
            }
            else if (orderByPageListInput.Property.ToUpper().Equals("DATECREATE"))
            {
                listData = resourceQuery.GetDateCreateOrderByAsc(orderByPageListInput);
            }
            else
            {
                listData = resourceQuery.GetAllListPage(orderByPageListInput);
            }

            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public async Task<PagedListOutput<ResourceDto>> ListOrderByAscResourceAsync(OrderByPageListInput orderByPageListInput)
        {
            IPagedList<Domain.Entitys.Resource> listData;

            if (orderByPageListInput.Property.ToUpper().Equals("NAME"))
            {
                listData = await resourceQuery.GetNameOrderByAscAsync(orderByPageListInput);
            }
            else if (orderByPageListInput.Property.ToUpper().Equals("DATECREATE"))
            {
                listData = await resourceQuery.GetDateCreateOrderByAscAsync(orderByPageListInput);
            }
            else
            {
                listData = await resourceQuery.GetAllListPageAsync(orderByPageListInput);
            }

            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public PagedListOutput<ResourceDto> ListOrderByDescResource(OrderByPageListInput orderByPageListInput)
        {
            IPagedList<Domain.Entitys.Resource> listData;

            if (orderByPageListInput.Property.ToUpper().Equals("NAME"))
            {
                listData = resourceQuery.GetNameOrderByDesc(orderByPageListInput);
            }
            else if (orderByPageListInput.Property.ToUpper().Equals("DATECREATE"))
            {
                listData = resourceQuery.GetDateCreateOrderByDesc(orderByPageListInput);
            }
            else
            {
                listData = resourceQuery.GetAllListPage(orderByPageListInput);
            }

            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public async Task<PagedListOutput<ResourceDto>> ListOrderByDescResourceAsync(OrderByPageListInput orderByPageListInput)
        {
            IPagedList<Domain.Entitys.Resource> listData;

            if (orderByPageListInput.Property.ToUpper().Equals("NAME"))
            {
                listData = await resourceQuery.GetNameOrderByDescAsync(orderByPageListInput);
            }
            else if (orderByPageListInput.Property.ToUpper().Equals("DATECREATE"))
            {
                listData = await resourceQuery.GetDateCreateOrderByDescAsync(orderByPageListInput);
            }
            else
            {
                listData = await resourceQuery.GetAllListPageAsync(orderByPageListInput);
            }

            return MapPagedListOutput.MapingpagedListOutput(listData);
        }

        public void InsertResource(ResourceDto resource)
        {
            if (resource.TypesRsc == null || resource.TypesRsc.ToUpper() != "URL")
            {
                throw new ClientException(400, "Invalid Types!");
            }
            if (resourceQuery.CountNameAndTypesExact(resource.Name, resource.TypesRsc) != 0)
            {
                throw new ClientException(400, "Url already exists!");
            }
            resourceQuery.Insert(MappingData.InitializeAutomapper().Map<Domain.Entitys.Resource>(resource));
        }

        public Task InsertResourceAsync(ResourceDto resource)
        {
            throw new System.NotImplementedException();
        }

        public int RemoveResource(List<int> ids)
        {
            return resourceQuery.RemoveMultiple(ids);
        }

        public Task<int> RemoveResourceAsync(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateResource(List<int> ids)
        {
            return resourceQuery.UpdateMultiple(ids);
        }

        public int UpdateResourceAsync(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public int EditResource(ResourceDto resourceDto)
        {
            var resource = MappingData.InitializeAutomapper().Map<Domain.Entitys.Resource>(resourceDto);
            resourceQuery.EditUnique(resource);
            return 1;
        }

        public int EditResourceAsync(ResourceDto resource)
        {
            throw new System.NotImplementedException();
        }
    }
}
