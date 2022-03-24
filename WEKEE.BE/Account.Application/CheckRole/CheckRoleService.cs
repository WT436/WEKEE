
using Account.Domain.BoundedContext;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.Shared.Entitys;
using Account.Infrastructure.ModelQuery;
using Account.Infrastructure.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Application.CheckRole
{
    public class CheckRoleService : ICheckRole
    {

        private readonly JoinQuery joinQuery = new JoinQuery();
        private readonly UrlProcess urlprocess = new UrlProcess();

        public List<RoleAuthDtos> RoleLst(int idAccount)
        {
            return null;
        }

        public Task<List<RoleAuthDtos>> RoleLstAsync(int idAccount)
        {
            throw new NotImplementedException();
        }

        public bool ListRole(string url, int id_User)
        {
            List<RoleAuthDtos> roleAnonimuosDtos;
            if (id_User == 0)
            {
                roleAnonimuosDtos = joinQuery.RoleAnonimuosDtos();
            }
            else
            {
                roleAnonimuosDtos = joinQuery.RoleAccount(id_User);
            }

            if (url.Length == 1 && url.Contains("/"))
            {
                return roleAnonimuosDtos.Any(m => m.NameResource.Equals(url.Trim()));
            }
            else
            {
                return urlprocess.CheckUrl(url, roleAnonimuosDtos);
            }
        }

        public Task<bool> ListRoleAsync(string url, string SessionAccount)
        {
            throw new System.NotImplementedException();
        }

        public List<RoleAuthDtos> RoleDtos(int user_Account_id)
        {
            return joinQuery.RoleAccount(user_Account_id);
        }

        public bool RoleUrl(string url, List<RoleAuthDtos> roleDtos)
        {
           return urlprocess.CheckUrl(url, roleDtos);
        }
    }
}
