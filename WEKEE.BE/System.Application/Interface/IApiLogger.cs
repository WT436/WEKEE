using System.Domain.Dtos;
using System.Threading.Tasks;
using UnitOfWork;

namespace System.Application.Interface
{
    public interface IApiLogger
    {
        void LogWarning(IUnitOfWork iUOW, Exception exception);
        Task LogError(InfomationError infomationError);
    }
}
