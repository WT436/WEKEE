using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    /// <summary>Thao tác với bảng Resource</summary>
    public interface IResource
    {
        /// <summary>Danh sách Resource căn bản</summary>
        PagedListOutput<ResourceDto> ListResourceBasic(PagedListInput pagedListInput);
        /// <summary>Danh sách Resource căn bản</summary>
        Task<PagedListOutput<ResourceDto>> ListResourceBasicAsync(PagedListInput pagedListInput);
        /// <summary>Danh sách Resource thứ tự tăng dần.</summary>
        PagedListOutput<ResourceDto> ListOrderByAscResource(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Resource thứ tự tăng dần.</summary>
        Task<PagedListOutput<ResourceDto>> ListOrderByAscResourceAsync(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Resource Thứ tự giảm dần.</summary>
        PagedListOutput<ResourceDto> ListOrderByDescResource(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Resource Thứ tự giảm dần.</summary>
        Task<PagedListOutput<ResourceDto>> ListOrderByDescResourceAsync(OrderByPageListInput orderByPageListInput);
        ///<summary>Thêm resource </summary>
        void InsertResource(ResourceDto resource);
        ///<summary>Thêm resource </summary>
        Task InsertResourceAsync(ResourceDto resource);
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
