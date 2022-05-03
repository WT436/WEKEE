using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class RoleEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                        new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<int> Insert(Role input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Role>().Insert(input);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateFull(Role input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Role>().Update(input);
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
                unitOfWork.GetRepository<Role>().Delete(id);
            }
            return unitOfWork.SaveChanges();
        }

        public async Task<int> UpdateIsActive(List<Role> inputs)
        {
            if (inputs.Count > 0)
            {
                unitOfWork.GetRepository<Role>().Update(inputs);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<bool> CheckAnyId(int id)
           => await unitOfWork.GetRepository<Role>().ExistsAsync(m => m.Id == id && m.IsActive == true);
        public async Task<bool> CheckAnyId(List<int> ids)
         => await unitOfWork.GetRepository<Role>().ExistsAsync(m => ids.Contains(m.Id) && m.IsActive == true);
    }
}
