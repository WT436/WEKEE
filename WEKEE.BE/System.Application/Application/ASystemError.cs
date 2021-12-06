using System;
using System.Application.Interface;
using System.Collections.Generic;
using System.Domain.Dtos;
using System.Domain.Entitys;
using System.Domain.ObjectValues;
using System.Infrastructure.MappingExtention;
using System.Infrastructure.Queries;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Collections;
using Utils.Exceptions;

namespace System.Application.Application
{
    public class ASystemError : ISystemError
    {
        private readonly ExceptionLogQuery _exceptionLogQuery = new ExceptionLogQuery();
        public async Task ChangStateFix(int id)
        {
            if (id == 0) throw new ClientException(400, "select Error!");
            var data = await _exceptionLogQuery.GetException(id: id);
            data.IsFix = !data.IsFix;
            await _exceptionLogQuery.UpdateFixException(data);
        }

        public async Task<PagedListOutput<ExceptionDtos>> GetAllPagedList(OrderByPageListInput orderByPageListInput)
        {
            var listData = orderByPageListInput.OrderBy switch
            {
                "Error" => await _exceptionLogQuery.GetAllPagedListOrderByErrorAsync(orderByPageListInput),
                "Wanning" => await _exceptionLogQuery.GetAllPagedListOrderByWanningAsync(orderByPageListInput),
                "ErrorFix" => await _exceptionLogQuery.GetAllPagedListOrderByErrorFixAsync(orderByPageListInput),
                "DateTime" => string.IsNullOrEmpty(orderByPageListInput.Property)
                             ? await _exceptionLogQuery.GetAllPagedListAsync(orderByPageListInput)
                             : await _exceptionLogQuery.GetAllPagedListOrderByDatetimeAsync(orderByPageListInput),
                _ => await _exceptionLogQuery.GetAllPagedListAsync(orderByPageListInput),
            };

            return new PagedListOutput<ExceptionDtos>
            {
                Items = listData.Items.Select(emp => MappingData.InitializeAutomapper()
                                                                .Map<ExceptionDtos>(emp)).ToList(),
                PageIndex = listData.PageIndex,
                PageSize = listData.PageSize,
                TotalCount = listData.TotalCount,
                TotalPages = listData.TotalPages
            };
        }
    }
}
