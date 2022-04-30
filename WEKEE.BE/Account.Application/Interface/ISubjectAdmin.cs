using Account.Domain.ObjectValues.Input;
using Account.Domain.ObjectValues.Output;
using Account.Domain.Shared.DataTransfer.SubjectDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interface
{
    public interface ISubjectAdmin
    {
        Task<PagedListOutput<SubjectReadDto>> GetSubjectPageList(SearchOrderPageInput input);
        Task<int> DeleteSubject(List<int> ids);
        Task<int> EditUnitSubject(SubjectLstChangeDto input);
        Task<int> InsertOrUpdateSubject(SubjectReadDto input, int idAccount);
    }
}
