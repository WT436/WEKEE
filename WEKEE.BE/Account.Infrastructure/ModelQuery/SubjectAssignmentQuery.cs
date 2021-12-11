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

        #region Truy Xuất - Read
        public async Task<List<SubjectAssignment>> GetAllJoinWithIdAccount(int id_Account)
        {
            return await unitOfWork.GetRepository<Subject>().GetAll()
                                                      .Where(m => m.Id == id_Account)
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
        #endregion

        #region Tạo mới - Create
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
        public int Insert(SubjectAssignment subjectAssignment)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Insert(subjectAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Insert(List<SubjectAssignment> subjectAssignments)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Insert(subjectAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(SubjectAssignment subjectAssignment)
        {
            await unitOfWork.GetRepository<SubjectAssignment>()
                            .InsertAsync(subjectAssignment);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> InsertAsync(List<SubjectAssignment> subjectAssignments)
        {
            await unitOfWork.GetRepository<SubjectAssignment>()
                            .InsertAsync(subjectAssignments);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Cập nhật - Update
        public int Update(SubjectAssignment subjectAssignment)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Update(subjectAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Update(List<SubjectAssignment> subjectAssignments)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Update(subjectAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> UpdateAsync(SubjectAssignment subjectAssignment)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Update(subjectAssignment);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(List<SubjectAssignment> subjectAssignments)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Update(subjectAssignments);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Xóa - Delete
        public int Delete(SubjectAssignment subjectAssignment)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Delete(subjectAssignment);
            return unitOfWork.SaveChanges();
        }
        public int Delete(List<SubjectAssignment> subjectAssignments)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Delete(subjectAssignments);
            return unitOfWork.SaveChanges();
        }
        public async Task<int> DeleteAsync(SubjectAssignment subjectAssignment)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Delete(subjectAssignment);
            return await unitOfWork.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(List<SubjectAssignment> subjectAssignments)
        {
            unitOfWork.GetRepository<SubjectAssignment>()
                      .Delete(subjectAssignments);
            return await unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
