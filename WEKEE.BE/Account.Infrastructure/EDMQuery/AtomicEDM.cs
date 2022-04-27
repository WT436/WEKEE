using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class AtomicEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                      new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<int> Insert(Atomic input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Atomic>().Insert(input);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateFull(Atomic input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Atomic>().Update(input);
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
                unitOfWork.GetRepository<Atomic>().Delete(id);
            }
            return unitOfWork.SaveChanges();
        }

        public async Task<int> UpdateIsActive(List<Atomic> Atomics)
        {
            if (Atomics.Count > 0)
            {
                unitOfWork.GetRepository<Atomic>().Update(Atomics);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
