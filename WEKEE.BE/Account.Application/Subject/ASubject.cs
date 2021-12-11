
using Account.Domain.Dto;
using Account.Infrastructure.MappingExtention;
using Account.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Subject
{
    public class ASubject : ISubject
    {
        private readonly SubjectQuery _subjectQuery = new SubjectQuery();

        public async Task<int> CreateSubjectAccounts(int id_account)
        {
            return await _subjectQuery.Create(id_Account: id_account);
        }

        public async Task<List<SubjectDtos>> LstSubjectAccounts(int id_account)
        {
            if (await _subjectQuery.CheckExists(id_Account: id_account))
            {
                var data = await _subjectQuery.GetAllWithId(id_Account: id_account);
                return data.Select(m => MappingData.InitializeAutomapper().Map<SubjectDtos>(m)).ToList();
            }
            return null;
        }

        public Task<int> RemoveSubjectAccounts(int id_Subject)
        {
            throw new NotImplementedException();
        }
    }
}
