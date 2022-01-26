using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;

namespace Account.Application.Atomic
{
    public interface IAtomic
    {
        /// <summary>Danh sách Atomic căn bản</summary>
        Task<PagedListOutput<AtomicDto>> ListAtomicBasicAsync(SearchOrderPageInput searchOrderPageInput);
        ///<summary>Thêm resource </summary>
        Task<int> InsertAtomicAsync(AtomicDto resource);
        ///<summary>Xóa tập thể</summary>
        int RemoveAtomic(List<int> ids);
        ///<summary>Update</summary>
        int UpdateAtomic(List<int> ids);
        ///<summary>Update</summary>
        int EditAtomic(AtomicDto resource);
    }
}
