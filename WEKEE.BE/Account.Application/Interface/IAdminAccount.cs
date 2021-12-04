using System.Threading.Tasks;
using UnitOfWork.Collections;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    public interface IAdminAccount
    {
        public Task<IPagedList<AccountShowDtos>> GetAllAccount(SearchOrderPageInput orderByPageListInput);
        public Task<bool> ChangStatusAccount(int id_account, int status);
        public Task<bool> RemoveAccount(int id_account);
    }
}
