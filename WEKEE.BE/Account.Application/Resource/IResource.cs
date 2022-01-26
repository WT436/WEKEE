using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;

namespace Account.Application.Resource
{
    /// <summary>Thao tác với bảng Resource</summary>
    public interface IResource
    {
        /// <summary>Danh sách Resource căn bản</summary>
        Task<PagedListOutput<ResourceDto>> ListResourceBasicAsync(SearchOrderPageInput searchOrderPageInput);
        /// <summary>Thêm resource </summary>
        Task<int> InsertResourceAsync(ResourceDto resource);
        ///<summary>Xóa tập thể</summary>
        int RemoveResource(List<int> ids);
        ///<summary>Update</summary>
        int UpdateResource(List<int> ids);
        ///<summary>Update</summary>
        int EditResource(ResourceDto resource);
    }
}
