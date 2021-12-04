using Account.Domain.Entitys;
using Account.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.ModelQuery
{
    public class SubjectAssignmentQuery
    {
        private readonly IUnitOfWork<AuthorizationContext> unitOfWork =
                           new UnitOfWork<AuthorizationContext>(new AuthorizationContext());

        public async Task CreateDefault(int id_Subject)
        {
            await unitOfWork.GetRepository<SubjectAssignment>().InsertAsync(new SubjectAssignment
            {
                RoleId = 2,
                SubjectId = id_Subject
            });

            unitOfWork.SaveChanges();
        }

        public async Task Create(int id_Subject, int id_RoleId)
        {
            await unitOfWork.GetRepository<SubjectAssignment>().InsertAsync(new SubjectAssignment
            {
                RoleId = id_RoleId,
                SubjectId = id_Subject
            });

            unitOfWork.SaveChanges();
        }

        public async Task Update(SubjectAssignment subjectAssignment)
        {
            unitOfWork.GetRepository<SubjectAssignment>().Update(subjectAssignment);
            unitOfWork.SaveChanges();
        }

        public async Task Delete(IEnumerable<SubjectAssignment> entities)
        {
            unitOfWork.GetRepository<SubjectAssignment>().Delete(entities: entities);
            unitOfWork.SaveChanges();
        }

        public async Task<List<SubjectAssignment>> GetAllJoinWithIdAccount(int id_Account)
        {
            return await unitOfWork.GetRepository<Subject>().GetAll()
                                                      .Where(m => m.UserAccountId == id_Account)
                                                      .Join(unitOfWork.GetRepository<SubjectAssignment>().GetAll(),
                                                            f => f.Id,
                                                            l => l.SubjectId,
                                                            (f, l) => l)
                                                      .ToListAsync();
        }

        public async Task<List<SubjectAssignment>> GetAllJoinWithIdSubject(int id_Subject)
        {
            return await unitOfWork.GetRepository<Subject>().GetAll()
                                                      .Where(m => m.Id == id_Subject)
                                                      .Join(unitOfWork.GetRepository<SubjectAssignment>().GetAll(),
                                                            f => f.Id,
                                                            l => l.SubjectId,
                                                            (f, l) => l)
                                                      .ToListAsync();
        }

        public async Task<SubjectAssignment> GetIdSubjectAndIdRole(int idSubject, int idRole)
        {
            return await unitOfWork.GetRepository<SubjectAssignment>()
                             .GetFirstOrDefaultAsync(predicate: m => m.SubjectId == idSubject && m.RoleId == idRole);
        }
    }
}
