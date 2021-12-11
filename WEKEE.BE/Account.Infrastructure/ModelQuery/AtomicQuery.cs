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

        
        #region truy xuất
        public async Task<IList<Atomic>> GetAllActive()
                     => await unitOfWork.GetRepository<Atomic>().GetAllAsync(m => m.IsActive == true);
        public IList<Atomic> GetAll()
               => unitOfWork.GetRepository<Atomic>().GetAll().ToList();
        public async Task<IList<Atomic>> GetAllAsync()
                     => await unitOfWork.GetRepository<Atomic>().GetAllAsync();
        #endregion truy xuất

        #region Tạo mới - Create
        public int Insert(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Insert(atomic);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Insert(atomics);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Atomic atomic)
        {
            await unitOfWork.GetRepository<Atomic>()
                            .InsertAsync(atomic);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Atomic> atomics)
        {
            await unitOfWork.GetRepository<Atomic>()
                            .InsertAsync(atomics);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomic);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomics);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomic);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Update(atomics);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomic);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomics);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Atomic atomic)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomic);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Atomic> atomics)
        {
            unitOfWork.GetRepository<Atomic>()
                      .Delete(atomics);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}