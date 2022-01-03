
using Account.Application.Action;
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

namespace Account.Application.ResourceAction
{
    public class AResourceAction : IResourceAction
    {
        private readonly ResourceQuery resourceQuery = new ResourceQuery();
        private readonly ActionQuery actionQuery = new ActionQuery();
        private readonly ResourceActionQuery resourceActionQuery = new ResourceActionQuery();
        public readonly AAction aAction = new AAction();
        public async Task<PagedListOutput<ActionResourceDto>> GetActionFromResourceAction(EntitySearchInput input)
        {
            // lấy dữ liệu Action theo pagelist
            var dataAction = await aAction.ListActionBasicAsync(input);
            // lấy dữ liệu resource action
            if (input.Id == 0)
            {
                return null;
            }
            var dataResourceAction = await resourceActionQuery.GetDataWithIdResource(input.Id);
            // map data
            var dto = dataAction.Items.Select(m =>
            {
                var data = MappingData.InitializeAutomapper().Map<ActionResourceDto>(m);
                data.IsCheck = dataResourceAction.Any(m => m.ActionId == data.Id && m.IsActive == true);
                return data;
            }).ToList();

            return new PagedListOutput<ActionResourceDto>
            {
                PageIndex = dataAction.PageIndex,
                PageSize = dataAction.PageSize,
                TotalPages = dataAction.TotalPages,
                TotalCount = dataAction.TotalCount,
                Items = dto
            };
        }

        public async Task<PagedListOutput<ResourceActionDto>> GetResourceFromResourceAction(EntitySearchInput input)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrInsertResourceAction(ActionResourceDto resourceActionDto)
        {
            // kieemr tra 
            if (resourceQuery.CountId(resourceActionDto.Id) != 1)
            {
                throw new ClientException(400, "Resource already exists!");
            }

            if (actionQuery.CountId(resourceActionDto.Id) != 1)
            {
                throw new ClientException(400, "Action already exists!");
            }

            var dataResourceAction = resourceActionQuery.CheckExistsUnique(resourceActionDto.Id, resourceActionDto.Id);
            if (dataResourceAction == null)
            {
                resourceActionQuery.Insert(new Domain.Entitys.ResourceAction
                {
                    ResourceId = resourceActionDto.Id,
                    ActionId = resourceActionDto.Id,
                    IsActive = true
                });
            }
            else
            {
                dataResourceAction.IsActive = !dataResourceAction.IsActive;

                resourceActionQuery.Update(dataResourceAction);
            }
        }
    }
}
