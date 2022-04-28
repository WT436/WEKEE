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
    }
}
