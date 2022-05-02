using Account.Domain.Shared.Entitys;
using Account.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Account.Infrastructure.EDMQuery
{
    public class ResourceEDM
    {
        private readonly IUnitOfWork<AuthorizationDBContext> unitOfWork =
                        new UnitOfWork<AuthorizationDBContext>(new AuthorizationDBContext());

        public async Task<int> Insert(Resource input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Resource>().Insert(input);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateFull(Resource input)
        {
            if (input != null)
            {
                unitOfWork.GetRepository<Resource>().Update(input);
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
                unitOfWork.GetRepository<Resource>().Delete(id);
            }
            return unitOfWork.SaveChanges();
        }

        public async Task<int> UpdateIsActive(List<Resource> resources)
        {
            if (resources.Count > 0)
            {
                unitOfWork.GetRepository<Resource>().Update(resources);
                return unitOfWork.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public async Task<bool> CheckAnyId(List<int> ids)
          => await unitOfWork.GetRepository<Permission>().ExistsAsync(m => ids.Contains(m.Id) && m.IsActive == true);
    }
}
