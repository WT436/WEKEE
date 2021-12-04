using Account.Application.Interface;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Application
{
    public class Action : IAction
    {
        private readonly ActionQuery actionQuery = new ActionQuery();
        private readonly IList<Domain.Entitys.Atomic> atomicListData = new AtomicQuery().GetAll();
        public int EditAction(ActionDto actionDto)
        {
            if (actionDto == null)
            {
                throw new ClientException(400, "You need to fill in all the information!");
            }
            if (actionDto.AtomicId == null
                || actionDto.AtomicId == 0
                || !atomicListData.Any(m => m.Id == actionDto.AtomicId))
            {
                throw new ClientException(400, "Invalid Atomic!");
            }

            if (actionQuery.CountId(actionDto.Id) != 1)
            {
                throw new ClientException(400, "Action already exists!");
            }

            var action = MappingData.InitializeAutomapper().Map<Domain.Entitys.Action>(actionDto);
            actionQuery.EditUnique(action);
            return 1;
        }

        public int EditActionAsync(ActionDto action)
        {
            throw new NotImplementedException();
        }

        public void InsertAction(ActionDto actionDto)
        {
            if (actionDto == null)
            {
                throw new ClientException(400, "You need to fill in all the information!");
            }

            if (actionDto.AtomicId == null
                || actionDto.AtomicId == 0
                || !atomicListData.Any(m => m.Id == actionDto.AtomicId))
            {
                throw new ClientException(400, "Invalid Atomic!");
            }

            if (actionDto.AtomicId == 3)
            {
                if (actionQuery.CountNameExact(actionDto.Name) != 0)
                {
                    throw new ClientException(400, "Action name  already exists!");
                }
            }
            else
            {
                //if (actionDto.ActionBase == null || actionDto.ActionBase == 0)
                //{
                //    throw new ClientException(400, "You need to fill in Action Base the information!");
                //}

                Domain.Entitys.Action data = new Domain.Entitys.Action();

                if (actionDto.ActionBase != 0)
                {
                   data = actionQuery.GetAllId((int)actionDto.ActionBase);
                }
              
                if (data == null || data.Name != actionDto.Name || data.ActionBase != null)
                {
                    throw new ClientException(400, "Action Base  already exists!");
                }
            }

            actionQuery.Insert(MappingData.InitializeAutomapper().Map< Domain.Entitys.Action >(actionDto));
        }

        public async Task InsertActionAsync(ActionDto actionDto)
        {
            if (actionDto.AtomicId == null
                || actionDto.AtomicId == 0
                || await actionQuery.CountAtomicAsync((int)actionDto.AtomicId) != 0)
            {
                throw new ClientException(400, "Invalid Atomic!");
            }

            if (actionQuery.CountNameExact(actionDto.Name) != 0)
            {
                throw new ClientException(400, "Action name  already exists!");
            }

            await actionQuery.InsertAsync(MappingData.InitializeAutomapper().Map<Domain.Entitys.Action>(actionDto));
        }

        public PagedListOutput<ActionDto> ListActionBasic(PagedListInput pagedListInput)
        {
            List<ActionDto> actionDtos = new List<ActionDto>();
            var listData = actionQuery.GetAllListPage(pagedListInput);
            if (listData.Items != null || listData.Items.Count != 0)
            {
                foreach (var item in listData.Items)
                {
                    var data = MappingData.InitializeAutomapper().Map<ActionDto>(item);
                    data.NameAtomic = atomicListData.FirstOrDefault(m => m.Id == data.AtomicId).Name;
                    actionDtos.Add(data);
                }
            }

            return new PagedListOutput<ActionDto>
            {
                Items = actionDtos,
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public async Task<PagedListOutput<ActionDto>> ListActionBasicAsync(PagedListInput pagedListInput)
        {
            List<ActionDto> actionDtos = new List<ActionDto>();
            var listData = await actionQuery.GetAllListPageAsync(pagedListInput);
            if (listData.Items != null || listData.Items.Count != 0)
            {
                foreach (var item in listData.Items)
                {
                    var data = MappingData.InitializeAutomapper().Map<ActionDto>(item);
                    data.Name = atomicListData.FirstOrDefault(m => m.Id == data.AtomicId).Name;
                    actionDtos.Add(data);
                }
            }

            return new PagedListOutput<ActionDto>
            {
                Items = actionDtos,
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public PagedListOutput<ActionDto> ListOrderByAscAction(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListOutput<ActionDto>> ListOrderByAscActionAsync(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public PagedListOutput<ActionDto> ListOrderByDescAction(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public Task<PagedListOutput<ActionDto>> ListOrderByDescActionAsync(OrderByPageListInput orderByPageListInput)
        {
            throw new NotImplementedException();
        }

        public int RemoveAction(List<int> ids)
        {
            return actionQuery.RemoveMultiple(ids);
        }

        public Task<int> RemoveActionAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdateAction(List<int> ids)
        {
            return actionQuery.UpdateMultiple(ids);
        }

        public int UpdateActionAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
