using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Subject
{
    public interface ISubject
    {
        Task<List<SubjectDtos>> LstSubjectAccounts(int id_account);
        Task<int> CreateSubjectAccounts(int id_account);
        Task<int> RemoveSubjectAccounts(int id_Subject);
    }
}
