
using Account.Domain.ObjectValues.ConstProperty;
using Account.Domain.Shared.DataTransfer.ResourceDTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Application.Service
{
    public interface ICheckRole
    {
        Task<List<UserGetPermission>> GetRoleServer(List<UserGetPermission> input);
        Task<List<UserGetPermission>> GetRoleClient(List<UserGetPermission> input);
    }

    public class CheckRoleService : ICheckRole
    {
        public async Task<List<UserGetPermission>> GetRoleServer(List<UserGetPermission> input)
        {
            var ouput = input.Where(n => (ResourceType)n.Type == ResourceType.ACTION
                                      || (ResourceType)n.Type == ResourceType.CONTROLLER)
                             .Select(m => m);
            return ouput.ToList();
        }

        public async Task<List<UserGetPermission>> GetRoleClient(List<UserGetPermission> input)
        {
            var ouput = input.Where(n => (ResourceType)n.Type == ResourceType.COMPONENT
                                       || (ResourceType)n.Type == ResourceType.SCENES)
                              .Select(m => m);
            return ouput.ToList();
        }
    }
}
