using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.AtomicDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface IAtomicAdmin
    {
        Task<PagedListOutput<AtomicReadDto>> GetAtomicPageList(SearchOrderPageInput input);
        Task<int> DeleteAtomic(List<int> ids);
        Task<int> EditUnitAtomic(AtomicLstChangeDto input);
        Task<int> InsertOrUpdateAtomic(AtomicReadDto input, int idAccount);
    }
}
