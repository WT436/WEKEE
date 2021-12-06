using System.Domain.Entitys;
using System.Domain.ObjectValues;
using System.Infrastructure.DBContext;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Collections;

namespace System.Infrastructure.Queries
{
    public class ExceptionLogQuery
    {
        private readonly IUnitOfWork<DbSystemContext> unitOfWork =
                                new UnitOfWork<DbSystemContext>(new DbSystemContext());
        public async Task<IPagedList<ExceptionLog>> GetAllPagedListOrderByDatetimeAsync(OrderByPageListInput orderByPageListInput)
                           => await unitOfWork.GetRepository<ExceptionLog>()
                                              .GetPagedListAsync(predicate: m => m.DateRaised.Date.Equals(DateTime.Parse(orderByPageListInput.Property).Date),
                                                                 pageIndex: orderByPageListInput.PageIndex,
                                                                 pageSize: orderByPageListInput.PageSize);
        public async Task<IPagedList<ExceptionLog>> GetAllPagedListOrderByErrorAsync(OrderByPageListInput orderByPageListInput)
                           => await unitOfWork.GetRepository<ExceptionLog>()
                                              .GetPagedListAsync(predicate: m => m.Level == "Error" && m.IsFix == false,
                                                                 pageIndex: orderByPageListInput.PageIndex,
                                                                 pageSize: orderByPageListInput.PageSize);
        public async Task<IPagedList<ExceptionLog>> GetAllPagedListOrderByErrorFixAsync(OrderByPageListInput orderByPageListInput)
                            => await unitOfWork.GetRepository<ExceptionLog>()
                                               .GetPagedListAsync(predicate: m => m.Level == "Error" && m.IsFix == true,
                                                                  pageIndex: orderByPageListInput.PageIndex,
                                                                  pageSize: orderByPageListInput.PageSize);
        public async Task<IPagedList<ExceptionLog>> GetAllPagedListOrderByWanningAsync(OrderByPageListInput orderByPageListInput)
                            => await unitOfWork.GetRepository<ExceptionLog>()
                                               .GetPagedListAsync(predicate: m => m.Level == "Wanning",
                                                                  pageIndex: orderByPageListInput.PageIndex,
                                                                  pageSize: orderByPageListInput.PageSize);

        public async Task<IPagedList<ExceptionLog>> GetAllPagedListAsync(OrderByPageListInput orderByPageListInput)
                            => await unitOfWork.GetRepository<ExceptionLog>()
                                               .GetPagedListAsync(predicate: m => m.DateRaised.Date.Equals(DateTime.Now.Date) && m.IsFix==false,
                                                                   pageIndex: orderByPageListInput.PageIndex,
                                                                   pageSize: orderByPageListInput.PageSize);

        public async Task<ExceptionLog> GetException(int id)
                      => await unitOfWork.GetRepository<ExceptionLog>()
                                         .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

        public async Task UpdateFixException(ExceptionLog exceptionLog)
        {
            unitOfWork.GetRepository<ExceptionLog>()
                             .Update(exceptionLog);
            unitOfWork.SaveChanges();
        }
    }
}
