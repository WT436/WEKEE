using System.Domain.Dtos;
using System.Domain.Entitys;
using System.Infrastructure.DBContext;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace System.Infrastructure.Queries
{
    public static class ProcessLogger
    {
        static IUnitOfWork<DbSystemContext> unitOfWork = new UnitOfWork<DbSystemContext>(new DbSystemContext());
        public static async Task WriteDb(InfomationError infomationError)
        {
            try
            {
                // lấy mã lỗi trong db
                var getOldError = await unitOfWork.GetRepository<ExceptionLog>().GetAllAsync();
                // nhận lại dữ liệu
                var checkDataError = getOldError.FirstOrDefault(m => infomationError.IpAccount.Equals(m.IpAccount)
                                    && infomationError.Level.Equals(m.Level)
                                    && infomationError.Exception.Message.Equals(m.ErrorMessage)
                                    && infomationError.Exception.StackTrace.Equals(m.ErrorTrace)
                                    && infomationError.AccountCreate.Equals(m.AccountCreate)
                                    );
                // lưu lại db
                if (checkDataError == null)
                {
                    checkDataError = await MapCreateExceptionLog(infomationError);
                    await unitOfWork.GetRepository<ExceptionLog>().InsertAsync(checkDataError);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    checkDataError.DateUpdate = DateTime.Now;
                    checkDataError = await MapUpdateExceptionLog(checkDataError);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static async Task<ExceptionLog> MapCreateExceptionLog(InfomationError exception)
                    => new ExceptionLog
                    {
                        ServerError = exception.ServerError,
                        AccountCreate = exception.AccountCreate,
                        IpAccount = exception.IpAccount,
                        Level = "Error",
                        ErrorMessage = exception.Exception.Message,
                        ErrorTrace = exception.Exception.StackTrace,
                        DateRaised = DateTime.Now,
                        DateUpdate = DateTime.Now,
                        UpdateCount = 0,
                    };
        private static async Task<ExceptionLog> MapUpdateExceptionLog(ExceptionLog exceptionLog)
        {
            exceptionLog.Id = exceptionLog.Id;
            exceptionLog.DateUpdate = DateTime.Now;
            exceptionLog.UpdateCount++;
            return exceptionLog;
        }
    }
}
