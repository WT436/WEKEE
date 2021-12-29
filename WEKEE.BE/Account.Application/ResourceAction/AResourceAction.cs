
using Account.Domain.BoundedContext;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Exceptions;

namespace Account.Application.ResourceAction
{
    public class AResourceAction : IResourceAction
    {
        private readonly ResourceQuery resourceQuery = new ResourceQuery();
        private readonly ActionQuery actionQuery = new ActionQuery();
        private readonly ResourceActionQuery resourceActionQuery = new ResourceActionQuery();
        public PagedListOutput<ActionResourceDto> ResourceActionDtos(int idAction, PagedListInput pagedListInput)
        {
            //lấy dữ liệu resource,
            var dataResoure = resourceQuery.GetAllListPage(pagedListInput);
            // lấy dữ liệu action
            var dataResoureAction = resourceActionQuery.ListResourceActionWithId(idAction);
            // map data
            return MapPagedListOutput.MapingpagedListOutput(resourceActions: dataResoureAction,
                                                                   resource: dataResoure,
                                                                   actionId: idAction);
        }

        public void UpdateOrInsertResourceAction(ActionResourceDto resourceActionDto)
        {
            // kieemr tra 
            if (resourceQuery.CountId(resourceActionDto.Id) != 1)
            {
                throw new ClientException(400, "Resource already exists!");
            }

            if (actionQuery.CountId(resourceActionDto.ActionId) != 1)
            {
                throw new ClientException(400, "Action already exists!");
            }

            var dataResourceAction = resourceActionQuery.CheckExistsUnique(resourceActionDto.Id, resourceActionDto.ActionId);
            if (dataResourceAction == null)
            {
                resourceActionQuery.Insert(new Domain.Entitys.ResourceAction
                {
                    ResourceId = resourceActionDto.Id,
                    ActionId = resourceActionDto.ActionId,
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
