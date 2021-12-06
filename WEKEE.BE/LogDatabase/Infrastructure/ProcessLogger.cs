using ContextDb.Context;
using ContextDb.Entity.DbSystem;
using LogDatabase.Infrastructure.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace LogDatabase.Infrastructure
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
                                    && DateTime.Now.ToString("dd:MM:yyyy").Equals(m.DateRaised?.ToString("dd:MM:yyyy"))
                                    );
                // lưu lại db
                if (checkDataError == null)
                {
                    checkDataError = await mapCreateExceptionLog(infomationError);
                    await unitOfWork.GetRepository<ExceptionLog>().InsertAsync(checkDataError);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    checkDataError = await mapUpdateExceptionLog(checkDataError);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        static async Task<ExceptionLog> mapCreateExceptionLog(InfomationError exception)
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
        static async Task<ExceptionLog> mapUpdateExceptionLog(ExceptionLog exceptionLog)
        {
            exceptionLog.Id = exceptionLog.Id;
            exceptionLog.DateUpdate = DateTime.Now;
            exceptionLog.UpdateCount++;
            return exceptionLog;
        }
    }
}
