using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;

namespace Account.Application.Resource
{
    /// <summary>Thao tác với bảng Resource</summary>
    public interface IResource
    {
        /// <summary>Danh sách Resource căn bản</summary>
        Task<PagedListOutput<ResourceDto>> ListResourceBasicAsync(SearchOrderPageInput searchOrderPageInput);
        ///<summary>Thêm resource </summary>
        int InsertResource(ResourceDto resource);
        ///<summary>Thêm resource </summary>
        Task<int> InsertResourceAsync(ResourceDto resource);
        ///<summary>Xóa tập thể</summary>
        int RemoveResource(List<int> ids);
        ///<summary>Xóa tập thể</summary>
        Task<int> RemoveResourceAsync(List<int> ids);
        ///<summary>Update</summary>
        int UpdateResource(List<int> ids);
        ///<summary>Update</summary>
        int UpdateResourceAsync(List<int> ids);
        ///<summary>Update</summary>
        int EditResource(ResourceDto resource);
        ///<summary>Update</summary>
        int EditResourceAsync(ResourceDto resource);
    }
}
