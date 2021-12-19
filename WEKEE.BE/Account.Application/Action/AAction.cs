using Account.Domain.Dto;
using Account.Domain.ObjectValues.Enum;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Account.Application.Action
{
    public class AAction : IAction
    {
        private readonly ActionQuery _actionQuery = new ActionQuery();
        private readonly UserAccountQuery _accountQuery = new UserAccountQuery();
        private readonly AtomicQuery _atomicQuery = new AtomicQuery();
        public int EditAction(ActionDto action)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertActionAsync(ActionDto action)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedListOutput<ActionDto>> ListActionBasicAsync(SearchOrderPageInput searchOrderPageInput)
        {
            var listData = await _actionQuery.GetAllListPageAsync(searchOrderPageInput);
            return new PagedListOutput<ActionDto>
            {
                Items = listData.Items.Select(emp =>
                {
                    var dataReturn = MappingData.InitializeAutomapper().Map<ActionDto>(emp);
                    dataReturn.CreateByName = _accountQuery.GetNameAccount(emp.CreateBy);
                    var atomicData = _atomicQuery.GetById(emp.AtomicId);
                    dataReturn.AtomicName = atomicData == null ? "" : atomicData.Name;
                    Domain.Entitys.Action actionData =
                    emp.ActionBase == null ? null : _actionQuery.GetById(emp.ActionBase);
                    dataReturn.ActionBaseName = actionData==null? "": actionData.Name;
                    return dataReturn;
                }).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }

        public int RemoveAction(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public int UpdateAction(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
