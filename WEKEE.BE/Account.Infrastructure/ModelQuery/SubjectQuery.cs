using Account.Domain.Entitys;
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
            return await unitOfWork.GetRepository<Subject>().GetAllAsync(predicate: m => m.UserAccountId == id_Account
                                                                                    && m.GorupId == null);
        }
        public async Task<IList<Subject>> GetAllWithIdSubject(int id_Subject)
        {
            return await unitOfWork.GetRepository<Subject>().GetAllAsync(predicate: m => m.Id == id_Subject);
        }
        public async Task<bool> CheckExists(int id_Account)
        {
            return await unitOfWork.GetRepository<Subject>()
                                    .ExistsAsync(m => m.UserAccountId == id_Account);
        }
        public async Task<bool> CheckIdExists(int id_Subject)
        {
            return await unitOfWork.GetRepository<Subject>()
                                    .ExistsAsync(m => m.Id == id_Subject);
        }

        public async Task<int> Create(int id_Account)
        {
            Subject subject = new Subject
            {
                UserAccountId = id_Account
            };

            await unitOfWork.GetRepository<Subject>()
                            .InsertAsync(subject);
            unitOfWork.SaveChanges();
            return subject.Id;
        }

        public async Task Delete(IEnumerable<Subject> subjects)
        {
            unitOfWork.GetRepository<Subject>().Delete(entities: subjects);
            unitOfWork.SaveChanges();
        }

        public async Task<int> ReadId(int id_Account)
        {
            var singeSubject = await unitOfWork.GetRepository<Subject>()
                                   .GetFirstOrDefaultAsync(predicate: m => m.UserAccountId == id_Account);
            return singeSubject.Id;
        }

    }
}
