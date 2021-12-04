using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class AtomicQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                          new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<IList<Atomic>> GetAllActive()
                     => await unitOfWork.GetRepository<Atomic>().GetAllAsync(m => m.IsActive == true);

        #region Hiển thị
        public IList<Atomic> GetAll()
               =>  unitOfWork.GetRepository<Atomic>().GetAll().ToList();
        public async Task<IList<Atomic>> GetAllAsync()
                     => await unitOfWork.GetRepository<Atomic>().GetAllAsync();
        #endregion
    }
}
