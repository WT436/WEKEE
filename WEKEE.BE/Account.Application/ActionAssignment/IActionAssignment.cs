using Account.Domain.Dto;
using Account.Domain.ObjectValues;
using Account.Domain.ObjectValues.Enum;
using System.Threading.Tasks;

namespace Account.Application.ActionAssignment
{
    public interface IActionAssignment
    {
        /// <summary>
        /// Danh sách kết nối giữa Action và permission
        /// </summary>
        public PagedListOutput<ActionAssignmentDto> ListActionAssignment(int idPermission, PagedListInput pagedListInput);

        /// <summary>
        /// Update hoặc thêm mới bản ghi
        /// </summary>
        public void UpdateOrInsert(ActionAssignmentDto resourceActionDto);      
    }
}
