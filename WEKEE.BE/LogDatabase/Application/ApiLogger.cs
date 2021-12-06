using ContextDb.Context;
using LogDatabase.Infrastructure;
using LogDatabase.Infrastructure.Dtos;
//using ContextDb.Entity.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace LogDatabase.Application
{
    public class ApiLogger : IApiLogger
    {
        public async Task LogError(InfomationError infomationError)
        {
            await ProcessLogger.WriteDb(infomationError);
        }

        public void LogWarning(IUnitOfWork iUOW, Exception exception)
        {

        }
    }
}
