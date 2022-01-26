using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class SubjectQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task<IList<Subject>> GetAll()
        {
            return await unitOfWork.GetRepository<Subject>().GetAllAsync();
        }
        public async Task<IList<Subject>> GetAllWithId(int id_Account)
        {
            return await unitOfWork.GetRepository<Subject>().GetAllAsync(predicate: m => m.Id == id_Account
                                                                                    && m.GorupId == null);
        }
        public async Task<IList<Subject>> GetAllWithIdSubject(int id_Subject)
        {
            return await unitOfWork.GetRepository<Subject>().GetAllAsync(predicate: m => m.Id == id_Subject);
        }
        public async Task<bool> CheckExists(int id_Account)
        {
            return await unitOfWork.GetRepository<Subject>()
                                    .ExistsAsync(m => m.Id == id_Account);
        }
        public async Task<bool> CheckIdExists(int id_Subject)
        {
            return await unitOfWork.GetRepository<Subject>()
                                    .ExistsAsync(m => m.Id == id_Subject);
        }


        public async Task<int> ReadId(int id_Account)
        {
            var singeSubject = await unitOfWork.GetRepository<Subject>()
                                   .GetFirstOrDefaultAsync(predicate: m => m.Id == id_Account);
            return singeSubject.Id;
        }

        #region Tạo mới - Create
        public async Task<int> Create(int id_Account)
        {
            Subject subject = new Subject
            {
                Id = id_Account
            };

            await unitOfWork.GetRepository<Subject>()
                            .InsertAsync(subject);
            unitOfWork.SaveChanges();
            return subject.Id;
        }
        public int Insert(Subject subject)
        {
            unitOfWork.GetRepository<Subject>()
                      .Insert(subject);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<Subject> subjects)
        {
            unitOfWork.GetRepository<Subject>()
                      .Insert(subjects);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(Subject subject)
        {
            await unitOfWork.GetRepository<Subject>()
                            .InsertAsync(subject);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<Subject> subjects)
        {
            await unitOfWork.GetRepository<Subject>()
                            .InsertAsync(subjects);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(Subject subject)
        {
            unitOfWork.GetRepository<Subject>()
                      .Update(subject);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<Subject> subjects)
        {
            unitOfWork.GetRepository<Subject>()
                      .Update(subjects);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(Subject subject)
        {
            unitOfWork.GetRepository<Subject>()
                      .Update(subject);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<Subject> subjects)
        {
            unitOfWork.GetRepository<Subject>()
                      .Update(subjects);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(int id)
        {
            unitOfWork.GetRepository<Subject>()
                      .Delete(id);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<int> ids)
        {
            unitOfWork.GetRepository<Subject>()
                      .Delete(ids);
            return unitOfWork.SaveChanges();
        }
        public int Delete(Subject subject)
        {
            unitOfWork.GetRepository<Subject>()
                      .Delete(subject);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<Subject> subjects)
        {
            unitOfWork.GetRepository<Subject>()
                      .Delete(subjects);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(Subject subject)
        {
            unitOfWork.GetRepository<Subject>()
                      .Delete(subject);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<Subject> subjects)
        {
            unitOfWork.GetRepository<Subject>()
                      .Delete(subjects);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
