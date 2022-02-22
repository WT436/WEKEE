using Account.Domain.Shared.DataTransfer;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using System.Threading.Tasks;

namespace Account.Application.ActionAssignment
{
    public interface IActionAssignment
    {
        /// <summary>
        /// Lấy danh sách action và trạng thái check của bản ghi với permisson
        /// </summary>
        /// <param name="idPermission"></param>
        /// <param name="pagedListInput"> phân trang đầu vào</param>
        /// <returns>dữ liệu của action kèm theo check</returns>
        public Task<PagedListOutput<ActionAssignmentDto>> ListActionAssignment(int idPermission, PagedListInput pagedListInput);

        /// <summary>
        /// chỉ cập nhật hoặc insert 
        /// </summary>
        /// <param name="resourceActionDto"> dữ liệu cần cập nhật</param>
        /// <returns>số bản ghi thành công</returns>
        public Task<int> UpdateOrInsert(ActionAssignmentDto resourceActionDto);

        /// <summary>
        /// Lấy danh sách action dựa theo id của atomic kèm theo trạng thái check
        /// </summary>
        /// <param name="idAtomic">id hành động căn bản</param>
        /// <param name="pageIndex"> Trang hiển thị</param>
        /// <param name="pageSize">số bản ghi 1 trang</param>
        /// <returns></returns>
        public Task<PagedListOutput<ActionAssignmentDto>> GetActionByAtomic(int idAtomic, int pageIndex, int pageSize);
    }
}
