using System.Application.Interface;
using System.Domain.Dtos;
using System.Infrastructure.Queries;
using System.Threading.Tasks;
using UnitOfWork;

namespace System.Application.Application
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
