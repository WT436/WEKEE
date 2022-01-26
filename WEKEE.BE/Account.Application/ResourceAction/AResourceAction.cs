
using Account.Application.Action;
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

        public async Task<int> UpdateOrInsertResourceAction(ActionResourceUpdateDto actionResourceUpdateDto)
        {
            if (actionResourceUpdateDto == null)
            {
                throw new ClientException(400, "Data input already exists!");
            }
            int isSussces = 0;
            // check isResource
            // if == true => id = id resource; DataUpdate = list id action
            if (actionResourceUpdateDto.IsResource)
            {
                List<Domain.Shared.Entitys.ResourceAction> DataInsert = new List<Domain.Shared.Entitys.ResourceAction>();
                List<Domain.Shared.Entitys.ResourceAction> DataUpdate = new List<Domain.Shared.Entitys.ResourceAction>();
                foreach (string item in actionResourceUpdateDto.DataUpdate)
                {
                    // convert id string to int
                    if (int.TryParse(item, out int idAction))
                    {
                        // kiểm tra tồn tại resource
                        if (resourceQuery.CountId(actionResourceUpdateDto.Id) != 1)
                        {
                            throw new ClientException(400, "Resource already exists!");
                        }
                        // kiểm tra tồn tại action
                        if (actionQuery.CountId(idAction) != 1)
                        {
                            throw new ClientException(400, "Action already exists!");
                        }

                        var dataResourceAction = await resourceActionQuery.CheckExistsUniqueAsync(actionResourceUpdateDto.Id, idAction);
                        if (dataResourceAction == null)
                        {
                            DataInsert.Add(new Domain.Shared.Entitys.ResourceAction
                            {
                                ResourceId = actionResourceUpdateDto.Id,
                                ActionId = idAction,
                                IsActive = true
                            });
                        }
                        else
                        {
                            dataResourceAction.IsActive = !dataResourceAction.IsActive;
                            DataUpdate.Add(dataResourceAction);
                        }
                    }
                }

                if (DataInsert.Count > 0)
                {
                    isSussces += resourceActionQuery.Insert(DataInsert);
                }
                if (DataUpdate.Count > 0)
                {
                    isSussces += resourceActionQuery.Update(DataUpdate);
                }
               
                return isSussces;
            }
            else
            {
                return isSussces;
            }

          
        }
    }
}
