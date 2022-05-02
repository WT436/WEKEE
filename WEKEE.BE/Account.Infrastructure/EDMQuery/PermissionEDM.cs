using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class PermissionEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                        new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<int> Insert(Permission input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Permission>().Insert(input);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateFull(Permission input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Permission>().Update(input);
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
                unitOfWork.GetRepository<Permission>().Delete(id);
            }
            return unitOfWork.SaveChanges();
        }

        public async Task<int> UpdateIsActive(List<Permission> inputs)
        {
            if (inputs.Count > 0)
            {
                unitOfWork.GetRepository<Permission>().Update(inputs);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<bool> CheckAnyId(int id)
            => await unitOfWork.GetRepository<Permission>().ExistsAsync(m => m.Id == id && m.IsActive == true);

        public async Task<int> InsertReourceAssignment(List<ReourceAssignment> input)
        {
            unitOfWork.GetRepository<ReourceAssignment>().Insert(input);
            return unitOfWork.SaveChanges();
        }

        public async Task<int> UpdateReourceAssignment(List<ReourceAssignment> inputs)
        {
            unitOfWork.GetRepository<ReourceAssignment>().Update(inputs);
            return unitOfWork.SaveChanges();
        }
    }
}
