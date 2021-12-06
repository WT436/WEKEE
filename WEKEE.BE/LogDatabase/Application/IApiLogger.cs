using LogDatabase.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace LogDatabase.Application
{
    public interface IApiLogger
    {
        void LogWarning(IUnitOfWork iUOW, Exception exception);
        Task LogError(InfomationError infomationError);
    }
}
