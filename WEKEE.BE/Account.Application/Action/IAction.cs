using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Action
{
    /// <summary>Thao tác với bảng Action</summary>
    public interface IAction
    {
        /// <summary>Danh sách Action căn bản</summary>
        PagedListOutput<ActionDto> ListActionBasic(PagedListInput pagedListInput);
        /// <summary>Danh sách Action căn bản</summary>
        Task<PagedListOutput<ActionDto>> ListActionBasicAsync(PagedListInput pagedListInput);
        /// <summary>Danh sách Action thứ tự tăng dần.</summary>
        PagedListOutput<ActionDto> ListOrderByAscAction(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Action thứ tự tăng dần.</summary>
        Task<PagedListOutput<ActionDto>> ListOrderByAscActionAsync(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Action Thứ tự giảm dần.</summary>
        PagedListOutput<ActionDto> ListOrderByDescAction(OrderByPageListInput orderByPageListInput);
        /// <summary>Danh sách Action Thứ tự giảm dần.</summary>
        Task<PagedListOutput<ActionDto>> ListOrderByDescActionAsync(OrderByPageListInput orderByPageListInput);
        ///<summary>Thêm Action </summary>
        void InsertAction(ActionDto action);
        ///<summary>Thêm Action </summary>
        Task InsertActionAsync(ActionDto action);
        ///<summary>Xóa tập thể</summary>
        int RemoveAction(List<int> ids);
        ///<summary>Xóa tập thể</summary>
        Task<int> RemoveActionAsync(List<int> ids);
        ///<summary>Update</summary>
        Task<int> UpdateActionAsync(List<int> ids);
        ///<summary>Update</summary>
        Task<int> EditAction(ActionDto action);
        ///<summary>Update</summary>
        int EditActionAsync(ActionDto action);
    }
}
