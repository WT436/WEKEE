using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class SubjectEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                       new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<int> Insert(Subject input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Subject>().Insert(input);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateFull(Subject input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Subject>().Update(input);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                unitOfWork.GetRepository<Subject>().Delete(id);
            }
            return unitOfWork.SaveChanges();
        }

        public async Task<int> UpdateIsActive(List<Subject> inputs)
        {
            if (inputs.Count > 0)
            {
                unitOfWork.GetRepository<Subject>().Update(inputs);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
