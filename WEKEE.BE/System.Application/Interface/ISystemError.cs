using System;
using System.Collections.Generic;
using System.Domain.Dtos;
using System.Domain.Entitys;
using System.Domain.ObjectValues;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Collections;

namespace System.Application.Interface
{
    public interface ISystemError
    {
        Task<PagedListOutput<ExceptionDtos>> GetAllPagedList(OrderByPageListInput orderByPageListInput);
        Task ChangStateFix(int id);
    }
}
