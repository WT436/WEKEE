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
        Task<PagedListOutput<ActionDto>> ListActionBasicAsync(SearchOrderPageInput searchOrderPageInput);
        /// <summary>Thêm action </summary>
        Task<int> InsertActionAsync(ActionDto action);
        ///<summary>Xóa tập thể</summary>
        int RemoveAction(List<int> ids);
        ///<summary>Update</summary>
        int UpdateAction(List<int> ids);
        ///<summary>Update</summary>
        int EditAction(ActionDto action);
    }
}
