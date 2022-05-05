using Account.Domain.Shared.DataTransfer.ResourceDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface ICheckRole
    {
        Task<List<UserGetPermission>> GetRoleServer(List<UserGetPermission> input);
        Task<List<UserGetPermission>> GetRoleClient(List<UserGetPermission> input);
    }
}
